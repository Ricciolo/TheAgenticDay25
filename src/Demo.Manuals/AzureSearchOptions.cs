namespace Demo.Manuals;

/// <summary>
/// Opzioni di configurazione per Azure AI Search.
/// </summary>
public class AzureSearchOptions
{
    /// <summary>
    /// Endpoint del servizio Azure Search.
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>
    /// Chiave API per l'autenticazione al servizio Azure Search.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Nome dell'indice di ricerca.
    /// </summary>
    public string IndexName { get; set; } = string.Empty;
}
