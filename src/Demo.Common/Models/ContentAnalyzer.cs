namespace Demo.Common.Models;

/// <summary>
/// Analyzer che estrae contenuti e campi da documenti multimodali
/// </summary>
public class ContentAnalyzer
{
    /// <summary>
    /// Identificatore univoco dell'analyzer
    /// </summary>
    public required string AnalyzerId { get; init; }

    /// <summary>
    /// Descrizione dell'analyzer
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Tag associati all'analyzer
    /// </summary>
    public Dictionary<string, string>? Tags { get; init; }

    /// <summary>
    /// Stato dell'analyzer
    /// </summary>
    public required ContentAnalyzerStatus Status { get; init; }

    /// <summary>
    /// Data e ora di creazione dell'analyzer
    /// </summary>
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// Data e ora dell'ultima modifica dell'analyzer
    /// </summary>
    public DateTime? LastModifiedAt { get; init; }

    /// <summary>
    /// Analyzer da cui eseguire l'allenamento incrementale
    /// </summary>
    public string? BaseAnalyzerId { get; init; }

    /// <summary>
    /// Impostazioni di configurazione dell'analyzer
    /// </summary>
    public ContentAnalyzerConfig? Config { get; init; }

    /// <summary>
    /// Schema dei campi da estrarre
    /// </summary>
    public ContentFieldSchema? FieldSchema { get; init; }

    /// <summary>
    /// Sorgenti di conoscenza aggiuntive per migliorare l'analyzer
    /// </summary>
    public KnowledgeSource[]? KnowledgeSources { get; init; }

    /// <summary>
    /// Mapping tra ruoli di modelli e nomi di modelli specifici
    /// </summary>
    public Dictionary<string, string>? Models { get; init; }

    /// <summary>
    /// Ubicazione in cui i dati possono essere elaborati
    /// </summary>
    public ProcessingLocation ProcessingLocation { get; init; } = ProcessingLocation.Global;

    /// <summary>
    /// Modelli di completamento chat e embedding supportati dall'analyzer
    /// </summary>
    public SupportedModels? SupportedModels { get; init; }

    /// <summary>
    /// Indica se il risultato pu� contenere campi aggiuntivi al di fuori dello schema definito
    /// </summary>
    public bool DynamicFieldSchema { get; init; }

    /// <summary>
    /// Avvertimenti riscontrati durante la creazione dell'analyzer
    /// </summary>
    public Error[]? Warnings { get; init; }
}
