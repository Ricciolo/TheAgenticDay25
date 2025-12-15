using System.Text.Json;

namespace Demo.Common.Models;

/// <summary>
/// Richiesta di operazione di analisi
/// </summary>
public class AnalyzeRequest
{
    /// <summary>
    /// Input da analizzare. Attualmente, solo la modalità pro supporta più input
    /// </summary>
    public required AnalyzeInput[] Inputs { get; init; }

    /// <summary>
    /// Mapping facoltativo per sovrascrivere il mapping predefinito dei nomi dei modelli ai deployment.
    /// Es. { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }
    /// </summary>
    public JsonElement? ModelDeployments { get; init; }
}
