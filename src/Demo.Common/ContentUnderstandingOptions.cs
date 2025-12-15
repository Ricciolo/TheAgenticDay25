namespace Demo.Common;

/// <summary>
/// Opzioni di configurazione per il servizio Content Understanding
/// </summary>
public class ContentUnderstandingOptions
{

    /// <summary>
    /// Endpoint del servizio Content Understanding (es. https://myendpoint.cognitiveservices.azure.com)
    /// </summary>
    public required string Endpoint { get; set; }

    /// <summary>
    /// Chiave API per l'autenticazione al servizio Content Understanding
    /// </summary>
    public required string ApiKey { get; set; }
}
