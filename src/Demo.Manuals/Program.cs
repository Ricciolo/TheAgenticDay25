using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Demo.Common;
using Demo.Common.Models;
using Demo.Manuals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

// ============================================================================
// CONFIGURAZIONE DELL'HOST E DEPENDENCY INJECTION
// ============================================================================

var app = Host.CreateApplicationBuilder();

// Configura le opzioni Content Understanding dalla configurazione (appsettings.json)
app.Services.Configure<ContentUnderstandingOptions>(
    app.Configuration.GetSection("ContentUnderstanding"));

// Configura le opzioni Azure Search dalla configurazione (appsettings.json)
app.Services.Configure<AzureSearchOptions>(
    app.Configuration.GetSection("AzureSearch"));

// Registra il servizio dell'API Content Understanding nel contenitore DI
app.Services.AddContentUnderstandingApi();

// Registra i servizi Azure Search con API Key
app.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<AzureSearchOptions>>().Value;
    var credential = new AzureKeyCredential(options.ApiKey);
    return new SearchIndexClient(new Uri(options.Endpoint), credential);
});

app.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<AzureSearchOptions>>().Value;
    var indexClient = sp.GetRequiredService<SearchIndexClient>();
    return indexClient.GetSearchClient(options.IndexName);
});

// Costruisce e avvia l'host dell'applicazione
var host = app.Build();

// Ottiene le istanze dei servizi registrati
var cu = host.Services.GetRequiredService<IContentUnderstandingApi>();
var searchIndexClient = host.Services.GetRequiredService<SearchIndexClient>();
var searchClient = host.Services.GetRequiredService<SearchClient>();
var searchOptions = host.Services.GetRequiredService<IOptions<AzureSearchOptions>>().Value;
var logger = host.Services.GetRequiredService<ILogger<Program>>();

// ============================================================================
// FASE 1: INDICIZZAZIONE
// ============================================================================
// Analizza i file, estrae il contenuto Markdown e lo indicizza in Azure Search

//await IndexDocumentsAsync();

// ============================================================================
// FASE 2: RICERCA
// ============================================================================
// Esegue una query di esempio sull'indice Azure Search

await SearchDocumentsAsync("CrystalDry"); // Query di esempio

return;

// ============================================================================
// METODI HELPER
// ============================================================================

/// <summary>
/// Fase di indicizzazione: analizza i documenti e li carica su Azure Search.
/// </summary>
async Task IndexDocumentsAsync()
{
    // Crea o aggiorna l'indice di ricerca
    await CreateOrUpdateIndexAsync();

    // Carica tutti i file dalla directory di input
    var files = Directory.EnumerateFiles(@"..\..\..\input").ToList();

    if (files.Count == 0)
    {
        logger.LogWarning("Nessun file trovato nella directory di input");
        return;
    }

    // Mappa per tracciare le operazioni: operationId -> filePath
    var pendingOperations = new Dictionary<string, string>();

    // Avvia l'analisi asincrona per tutti i file
    foreach (var file in files)
    {
        logger.LogInformation("Avvio analisi per {file}", file);

        await using var fileStream = File.OpenRead(file);
        var analyzeResult = await cu.AnalyzeBinaryAsync("prebuilt-documentSearch", fileStream);

        logger.LogInformation("Operazione {operationId} avviata - Status: {status}",
            analyzeResult.Id, analyzeResult.Status);

        pendingOperations[analyzeResult.Id] = file;
    }

    // Polling dei risultati e indicizzazione
    var documentsToIndex = new List<ManualDocument>();

    while (pendingOperations.Count > 0)
    {
        var operationId = pendingOperations.Keys.First();
        var filePath = pendingOperations[operationId];

        var result = await cu.GetResultAsync(operationId);

        if (result.Status != OperationState.Running)
        {
            pendingOperations.Remove(operationId);

            if (result.Status == OperationState.Succeeded &&
                result.Result?.Contents?.FirstOrDefault() is DocumentContent documentContent)
            {
                // Estrae il contenuto Markdown dal documento analizzato
                var markdown = documentContent.Markdown ?? string.Empty;

                logger.LogInformation("Documento {file} analizzato - Lunghezza Markdown: {length} caratteri",
                    filePath, markdown.Length);

                // Esegue il chunking del Markdown basato sui titoli # e ##
                var chunks = ChunkMarkdownByHeaders(markdown);
                var baseId = GenerateDocumentId(filePath);
                var fileName = Path.GetFileName(filePath);

                logger.LogInformation("Documento {file} suddiviso in {count} chunk",
                    filePath, chunks.Count);

                // Crea un documento per ogni chunk
                for (var i = 0; i < chunks.Count; i++)
                {
                    var chunk = chunks[i];
                    var document = new ManualDocument
                    {
                        Id = $"{baseId}_chunk{i}",
                        FileName = fileName,
                        SectionTitle = chunk.Title,
                        ChunkIndex = i,
                        Content = chunk.Content,
                        IndexedAt = DateTimeOffset.UtcNow
                    };

                    documentsToIndex.Add(document);

                    logger.LogDebug("Chunk {index}: '{title}' - {length} caratteri",
                        i, chunk.Title, chunk.Content.Length);
                }
            }
            else
            {
                logger.LogWarning("Analisi fallita per {file} - Status: {status}",
                    filePath, result.Status);
            }
        }
        else
        {
            // Attende prima di riprovare il polling
            await Task.Delay(1000);
        }
    }

    // Carica i documenti nell'indice Azure Search
    if (documentsToIndex.Count > 0)
    {
        logger.LogInformation("Caricamento di {count} chunk in Azure Search...", documentsToIndex.Count);

        try
        {
            var uploadResult = await searchClient.UploadDocumentsAsync(documentsToIndex);

            foreach (var indexResult in uploadResult.Value.Results)
            {
                logger.LogInformation("Chunk {key} indicizzato: {succeeded}",
                    indexResult.Key, indexResult.Succeeded);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Errore durante l'upload dei chunk in Azure Search");
        }
    }
}

/// <summary>
/// Suddivide il contenuto Markdown in chunk basandosi sui titoli # e ## all'inizio della linea.
/// </summary>
List<MarkdownChunk> ChunkMarkdownByHeaders(string markdown)
{
    var chunks = new List<MarkdownChunk>();
    
    // Regex per trovare le linee che iniziano con # o ## (titoli di livello 1 e 2)
    var headerPattern = new Regex(@"^(#{1,2})\s+(.+)$", RegexOptions.Multiline);
    var matches = headerPattern.Matches(markdown);

    if (matches.Count == 0)
    {
        // Nessun header trovato, restituisce l'intero documento come singolo chunk
        chunks.Add(new MarkdownChunk
        {
            Title = "Documento",
            Content = markdown.Trim()
        });
        return chunks;
    }

    // Se c'è contenuto prima del primo header, lo aggiunge come chunk introduttivo
    var firstMatchIndex = matches[0].Index;
    if (firstMatchIndex > 0)
    {
        var introContent = markdown[..firstMatchIndex].Trim();
        if (!string.IsNullOrWhiteSpace(introContent))
        {
            chunks.Add(new MarkdownChunk
            {
                Title = "Introduzione",
                Content = introContent
            });
        }
    }

    // Processa ogni sezione delimitata dagli header
    for (var i = 0; i < matches.Count; i++)
    {
        var currentMatch = matches[i];
        var title = currentMatch.Groups[2].Value.Trim();
        
        // Calcola l'indice di inizio del contenuto (dopo l'header)
        var contentStart = currentMatch.Index + currentMatch.Length;
        
        // Calcola l'indice di fine del contenuto (inizio del prossimo header o fine del documento)
        var contentEnd = i < matches.Count - 1 
            ? matches[i + 1].Index 
            : markdown.Length;

        var content = markdown[contentStart..contentEnd].Trim();

        // Include anche l'header nel contenuto per contesto
        var fullContent = $"{currentMatch.Value}\n\n{content}";

        chunks.Add(new MarkdownChunk
        {
            Title = title,
            Content = fullContent.Trim()
        });
    }

    return chunks;
}

/// <summary>
/// Crea o aggiorna l'indice Azure Search.
/// </summary>
async Task CreateOrUpdateIndexAsync()
{
    logger.LogInformation("Creazione/aggiornamento indice '{indexName}'...", searchOptions.IndexName);

    var fieldBuilder = new FieldBuilder();
    var searchFields = fieldBuilder.Build(typeof(ManualDocument));

    var index = new SearchIndex(searchOptions.IndexName, searchFields)
    {
        Suggesters =
        {
            new SearchSuggester("sg", "FileName", "SectionTitle", "Content")
        }
    };

    await searchIndexClient.CreateOrUpdateIndexAsync(index);

    logger.LogInformation("Indice '{indexName}' pronto", searchOptions.IndexName);
}

/// <summary>
/// Fase di ricerca: esegue una query sull'indice Azure Search.
/// </summary>
async Task SearchDocumentsAsync(string searchText)
{
    logger.LogInformation("Ricerca per: '{searchText}'", searchText);

    var options = new Azure.Search.Documents.SearchOptions
    {
        IncludeTotalCount = true,
        Size = 10,
        Select = { "Id", "FileName", "SectionTitle", "ChunkIndex", "IndexedAt" },
        HighlightFields = { "Content" },
        HighlightPreTag = "<mark>",
        HighlightPostTag = "</mark>"
    };

    try
    {
        var response = await searchClient.SearchAsync<ManualDocument>(searchText, options);

        logger.LogInformation("Trovati {count} risultati", response.Value.TotalCount);

        await foreach (var result in response.Value.GetResultsAsync())
        {
            logger.LogInformation("- {fileName} | Sezione: '{sectionTitle}' | Chunk: {chunkIndex} (Score: {score})",
                result.Document.FileName, result.Document.SectionTitle, result.Document.ChunkIndex, result.Score);

            // Mostra gli highlight se disponibili
            if (result.Highlights?.TryGetValue("Content", out var highlights) == true)
            {
                foreach (var highlight in highlights.Take(2))
                {
                    logger.LogInformation("  Highlight: ...{highlight}...",
                        highlight.Length > 100 ? highlight[..100] : highlight);
                }
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Errore durante la ricerca");
    }
}

/// <summary>
/// Genera un ID univoco per il documento basato sul percorso del file.
/// </summary>
string GenerateDocumentId(string filePath)
{
    // Usa il nome del file senza caratteri speciali come ID
    var fileName = Path.GetFileNameWithoutExtension(filePath);
    // Rimuove caratteri non validi per l'ID di Azure Search
    return string.Concat(fileName.Where(c => char.IsLetterOrDigit(c) || c == '-' || c == '_'));
}

/// <summary>
/// Rappresenta un chunk di contenuto Markdown con il suo titolo.
/// </summary>
record MarkdownChunk
{
    public required string Title { get; init; }
    public required string Content { get; init; }
}
