namespace Demo.Common.Models;

/// <summary>
/// Collezione paginata di elementi ContentAnalyzer
/// </summary>
public class PagedContentAnalyzer
{
    /// <summary>
    /// Elementi ContentAnalyzer in questa pagina
    /// </summary>
    public required ContentAnalyzer[] Value { get; init; }

    /// <summary>
    /// Collegamento alla pagina successiva di elementi
    /// </summary>
    public string? NextLink { get; init; }
}
