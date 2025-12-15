namespace Demo.Common.Models;

/// <summary>
/// Fornisce dettagli dello stato per le operazioni di analisi di un documento
/// </summary>
public class ContentAnalyzerAnalyzeOperationStatus
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
    /// Il risultato completo dell'operazione di analisi
    /// </summary>
    public AnalyzeOperationResult? Result { get; init; }

    /// <summary>
    /// Oggetto errore che descrive l'errore quando lo stato è "Failed"
    /// </summary>
    public Error? Error { get; init; }

    /// <summary>
    /// Dettagli di utilizzo dell'operazione di analisi
    /// </summary>
    public UsageDetails? Usage { get; init; }
}
