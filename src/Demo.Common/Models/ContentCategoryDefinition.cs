namespace Demo.Common.Models;

/// <summary>
/// Definizione della categoria di contenuto
/// </summary>
public class ContentCategoryDefinition
{
    /// <summary>
    /// La descrizione della categoria
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Analyzer facoltativo utilizzato per elaborare il contenuto
    /// </summary>
    public string? AnalyzerId { get; init; }

    /// <summary>
    /// Definizione inline facoltativa dell'analyzer utilizzato per elaborare il contenuto
    /// </summary>
    public ContentAnalyzer? Analyzer { get; init; }
}
