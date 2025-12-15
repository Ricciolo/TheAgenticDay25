using Microsoft.Extensions.Options;

namespace Demo.Common;

/// <summary>
/// DelegatingHandler per aggiungere l'autenticazione con API Key alle richieste
/// </summary>
internal class ContentUnderstandingAuthHandler : DelegatingHandler
{
    private readonly IOptions<ContentUnderstandingOptions> _options;

    /// <summary>
    /// Inizializza una nuova istanza del gestore di autenticazione
    /// </summary>
    /// <param name="options">Opzioni di configurazione Content Understanding</param>
    public ContentUnderstandingAuthHandler(IOptions<ContentUnderstandingOptions> options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Aggiunge l'header di autenticazione Ocp-Apim-Subscription-Key a ogni richiesta
    /// </summary>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add("Ocp-Apim-Subscription-Key", _options.Value.ApiKey);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
