namespace Demo.Common.Models;

/// <summary>
/// Sorgente di conoscenza
/// </summary>
public abstract class KnowledgeSource
{
    /// <summary>
    /// Il tipo di sorgente di conoscenza
    /// </summary>
    public required string Kind { get; init; }
}
