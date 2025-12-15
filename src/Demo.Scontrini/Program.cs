using Demo.Common;
using Demo.Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;

// ============================================================================
// CONFIGURAZIONE DELL'HOST E DEPENDENCY INJECTION
// ============================================================================

var app = Host.CreateApplicationBuilder();

// Configura le opzioni Content Understanding dalla configurazione (appsettings.json)
app.Services.Configure<ContentUnderstandingOptions>(
    app.Configuration.GetSection("ContentUnderstanding"));

// Registra il servizio dell'API Content Understanding nel contenitore DI
app.Services.AddContentUnderstandingApi();

// Costruisce e avvia l'host dell'applicazione
var host = app.Build();

// Ottiene le istanze dei servizi registrati
var cu = host.Services.GetRequiredService<IContentUnderstandingApi>();
var logger = host.Services.GetRequiredService<ILogger<Program>>();

// ============================================================================
// FASE 1: ANALISI DEI FILE
// ============================================================================
// Carica tutti i file dalla directory di input e avvia l'analisi asincrona

var files = Directory.EnumerateFiles(@"..\..\..\input");

var operationIds = new List<string>();
foreach (var file in files)
{
    // Log dell'inizio dell'analisi per il file corrente
    logger.LogInformation("Analyzing {file}", file);
    
    // Apre il file in modalità lettura e lo passa all'API
    // "await using" garantisce che lo stream venga chiuso automaticamente
    await using var fileStream = File.OpenRead(file);
    
    // Invia il file all'API per l'analisi (scontrini = ricevute)
    // L'operazione è asincrona e restituisce un ID operazione
    var analyzeResult = await cu.AnalyzeBinaryAsync("scontrini", fileStream);
    
    // Log del risultato: ID operazione e stato iniziale
    logger.LogInformation("Operation {operationId} Status: {status}", analyzeResult.Id, analyzeResult.Status);
    
    // Salva l'ID operazione per il polling successivo
    operationIds.Add(analyzeResult.Id);
}

// ============================================================================
// FASE 2: POLLING DEI RISULTATI
// ============================================================================
// Controlla periodicamente il stato di ogni operazione finché non sono completate

while (operationIds.Count > 0)
{
    var operationId = operationIds[0];
    // Recupera lo stato e il risultato dell'operazione in testa alla lista
    var result = await cu.GetResultAsync(operationId);
    
    // Se l'operazione è completata (non più in stato "Running")
    if (result.Status != OperationState.Running)
    {
        // Rimuove l'operazione completata dalla lista di tracking
        operationIds.RemoveAt(0);
        
        // Estrae l'importo totale dal risultato dell'analisi
        // Utilizza null-coalescing (?.) per gestire in sicurezza i dati mancanti
        var totalAmount = result.Result?.Contents?[0].Fields?["TotalAmount"].ValueNumber;
        
        // Log del risultato finale con l'importo totale estratto
        logger.LogInformation("Operation {operationId}. Total amount {totalAmount}", operationId, totalAmount);
    }
    else
    {
        // Se l'operazione è ancora in esecuzione, attende 1 secondo prima di riprovare
        // Questo evita di sovraccaricare l'API con richieste troppo frequenti
        await Task.Delay(1000);
    }
}

// Termina l'applicazione
return ;
