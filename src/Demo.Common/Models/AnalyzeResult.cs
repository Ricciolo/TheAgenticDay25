namespace Demo.Common.Models;

/// <summary>
/// Risultato dell'operazione di analisi.
/// </summary>
public class AnalyzeResult
{
    /// <summary>
    /// L'identificatore univoco dell'analizzatore.
    /// </summary>
    public string? AnalyzerId { get; init; }

    /// <summary>
    /// La versione dell'API utilizzata per analizzare il documento.
    /// </summary>
    public string? ApiVersion { get; init; }

    /// <summary>
    /// Il contenuto estratto.
    /// </summary>
    public List<DocumentContent>? Contents { get; init; }

    /// <summary>
    /// La data e l'ora in cui è stato creato il risultato.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; init; }

    /// <summary>
    /// Il formato di codifica delle stringhe per gli intervalli di contenuto nella risposta. I valori possibili sono 'codePoint', 'utf16' e 'utf8'. Il valore predefinito è 'codePoint'.
    /// </summary>
    public string? StringEncoding { get; init; }

    /// <summary>
    /// Avvisi riscontrati durante l'analisi del documento.
    /// </summary>
    public List<Error>? Warnings { get; init; }
}
