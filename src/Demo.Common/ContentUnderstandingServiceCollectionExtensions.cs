using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace Demo.Common;

/// <summary>
/// Metodi di estensione per la configurazione dei servizi Content Understanding
/// </summary>
public static class ContentUnderstandingServiceCollectionExtensions
{
    /// <summary>
    /// Configura il client Refit per l'API Content Understanding sulla Dependency Injection
    /// utilizzando le opzioni dalla configurazione
    /// </summary>
    /// <param name="services">Collezione di servizi</param>
    /// <returns>Collezione di servizi per il concatenamento di metodi</returns>
    public static IServiceCollection AddContentUnderstandingApi(
        this IServiceCollection services)
    {
        services.AddTransient<ContentUnderstandingAuthHandler>();

        services
            .AddRefitClient<IContentUnderstandingApi>()
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<ContentUnderstandingOptions>>().Value;
                client.BaseAddress = new Uri(options.Endpoint);
            })
            .AddHttpMessageHandler<ContentUnderstandingAuthHandler>();

        return services;
    }
}
