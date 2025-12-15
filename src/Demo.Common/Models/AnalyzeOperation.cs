namespace Demo.Common.Models;

/// <summary>
/// Risposta iniziale per le operazioni di analisi
/// </summary>
public class AnalyzeOperation
{
    /// <summary>
    /// Identificatore univoco dell'operazione
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Lo stato dell'operazione
    /// </summary>
    public required OperationState Status { get; init; }
}
