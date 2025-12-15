namespace Demo.Common.Models;

/// <summary>
/// Fornisce dettagli dello stato per le operazioni di creazione di un analyzer
/// </summary>
public class ContentAnalyzerOperationStatus
{
    /// <summary>
    /// Identificatore univoco dell'operazione
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Lo stato dell'operazione
    /// </summary>
    public required OperationState Status { get; init; }

    /// <summary>
    /// Il risultato dell'operazione
    /// </summary>
    public ContentAnalyzer? Result { get; init; }

    /// <summary>
    /// Oggetto errore che descrive l'errore quando lo stato è "Failed"
    /// </summary>
    public Error? Error { get; init; }

    /// <summary>
    /// Dettagli di utilizzo dell'operazione di creazione dell'analyzer
    /// </summary>
    public UsageDetails? Usage { get; init; }
}
