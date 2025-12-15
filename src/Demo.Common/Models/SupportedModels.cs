using System.Text.Json;

namespace Demo.Common.Models;

/// <summary>
/// Modelli di completamento chat e embedding supportati dall'analyzer
/// </summary>
public class SupportedModels
{
    /// <summary>
    /// Modelli di completamento chat supportati dall'analyzer
    /// </summary>
    public string[]? Completion { get; init; }

    /// <summary>
    /// Modelli di embedding supportati dall'analyzer
    /// </summary>
    public string[]? Embedding { get; init; }
}
