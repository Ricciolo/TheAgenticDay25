namespace Demo.Common.Models;

/// <summary>
/// Posizione dell'elemento nel markdown, specificata come offset di caratteri e lunghezza.
/// </summary>
public class ContentSpan
{
    /// <summary>
    /// Lunghezza dell'elemento nel markdown, specificata in caratteri.
    /// </summary>
    public int? Length { get; init; }

    /// <summary>
    /// Posizione iniziale (indicizzata a 0) dell'elemento nel markdown, specificata in caratteri.
    /// </summary>
    public int? Offset { get; init; }
}
