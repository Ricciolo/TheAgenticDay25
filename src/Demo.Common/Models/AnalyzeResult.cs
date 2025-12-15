namespace Demo.Common.Models;

/// <summary>
/// Risultato immediato di un'operazione di analisi di un documento
/// </summary>
public class AnalyzeResult
{
    /// <summary>
    /// Identificatore univoco dell'operazione di analisi
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Stato attuale dell'operazione di analisi
    /// </summary>
    public required OperationState Status { get; init; }
}
