namespace Demo.Common.Models;

/// <summary>
/// Risultato completo di un'operazione di analisi di un documento
/// </summary>
public class AnalyzeOperationResult
{
    /// <summary>
    /// Identificatore dell'analizzatore utilizzato
    /// </summary>
    public string? AnalyzerId { get; init; }

    /// <summary>
    /// Versione dell'API utilizzata
    /// </summary>
    public string? ApiVersion { get; init; }

    /// <summary>
    /// Data e ora di creazione del risultato
    /// </summary>
    public DateTime? CreatedAt { get; init; }

    /// <summary>
    /// Elenco degli avvisi generati durante l'analisi
    /// </summary>
    public List<object>? Warnings { get; init; }

    /// <summary>
    /// Elenco dei contenuti estratti dal documento
    /// </summary>
    public List<AnalyzedContent>? Contents { get; init; }

    /// <summary>
    /// Dettagli di utilizzo dell'operazione di analisi
    /// </summary>
    public UsageDetails? Usage { get; init; }

    /// <summary>
    /// Tipo di documento analizzato
    /// </summary>
    public string? Kind { get; init; }

    /// <summary>
    /// Tipo MIME del documento
    /// </summary>
    public string? MimeType { get; init; }

    /// <summary>
    /// Elenco delle pagine analizzate
    /// </summary>
    public List<PageDetails>? Pages { get; init; }
}

/// <summary>
/// Contenuto estratto dal documento
/// </summary>
public class AnalyzedContent
{
    /// <summary>
    /// Percorso del contenuto
    /// </summary>
    public string? Path { get; init; }

    /// <summary>
    /// Contenuto in formato Markdown
    /// </summary>
    public string? Markdown { get; init; }

    /// <summary>
    /// Campi estratti dal contenuto
    /// </summary>
    public Dictionary<string, FieldValue>? Fields { get; init; }

    /// <summary>
    /// Tipo di analizzatore utilizzato
    /// </summary>
    public string? AnalyzerId { get; init; }

    /// <summary>
    /// Tipo MIME del contenuto
    /// </summary>
    public string? MimeType { get; init; }

    /// <summary>
    /// Numero della pagina di inizio
    /// </summary>
    public int? StartPageNumber { get; init; }

    /// <summary>
    /// Numero della pagina di fine
    /// </summary>
    public int? EndPageNumber { get; init; }

    /// <summary>
    /// Unità di misura (pixel, inch, cm)
    /// </summary>
    public string? Unit { get; init; }
}

/// <summary>
/// Valore di un campo estratto
/// </summary>
public class FieldValue
{
    /// <summary>
    /// Tipo del valore
    /// </summary>
    public string? Type { get; init; }

    /// <summary>
    /// Valore come stringa
    /// </summary>
    public string? ValueString { get; init; }

    /// <summary>
    /// Valore come numero
    /// </summary>
    public double? ValueNumber { get; init; }

    /// <summary>
    /// Valore come intero
    /// </summary>
    public int? ValueInteger { get; init; }

    /// <summary>
    /// Valore come data
    /// </summary>
    public string? ValueDate { get; init; }

    /// <summary>
    /// Valore come array di oggetti
    /// </summary>
    public List<FieldValue>? ValueArray { get; init; }

    /// <summary>
    /// Valore come oggetto con proprietà
    /// </summary>
    public Dictionary<string, FieldValue>? ValueObject { get; init; }

    /// <summary>
    /// Intervalli di posizione del valore nel documento
    /// </summary>
    public List<Span>? Spans { get; init; }

    /// <summary>
    /// Livello di confidenza del valore
    /// </summary>
    public double? Confidence { get; init; }

    /// <summary>
    /// Fonte del valore estratto
    /// </summary>
    public string? Source { get; init; }
}

/// <summary>
/// Intervallo di posizione nel documento
/// </summary>
public class Span
{
    /// <summary>
    /// Offset iniziale
    /// </summary>
    public int? Offset { get; init; }

    /// <summary>
    /// Lunghezza dell'intervallo
    /// </summary>
    public int? Length { get; init; }
}

/// <summary>
/// Dettagli di una pagina del documento
/// </summary>
public class PageDetails
{
    /// <summary>
    /// Numero della pagina
    /// </summary>
    public int? PageNumber { get; init; }

    /// <summary>
    /// Angolo di rotazione della pagina
    /// </summary>
    public double? Angle { get; init; }

    /// <summary>
    /// Larghezza della pagina
    /// </summary>
    public double? Width { get; init; }

    /// <summary>
    /// Altezza della pagina
    /// </summary>
    public double? Height { get; init; }
}
