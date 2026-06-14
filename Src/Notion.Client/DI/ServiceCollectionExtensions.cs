using System;
using System.Diagnostics.CodeAnalysis;
using Notion.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers <see cref="INotionClient"/> as a singleton and configures the underlying
        /// <see cref="System.Net.Http.HttpClient"/> through <see cref="System.Net.Http.IHttpClientFactory"/>,
        /// which correctly manages handler lifetimes and DNS refresh for long-running applications.
        /// </summary>
        public static IServiceCollection AddNotionClient(
            this IServiceCollection services,
            Action<ClientOptions> configureOptions)
        {
            var clientOptions = new ClientOptions();
            configureOptions?.Invoke(clientOptions);

            // Register a named HttpClient managed by IHttpClientFactory.
            // IHttpClientFactory rotates the underlying HttpClientHandler periodically,
            // preventing stale DNS and socket exhaustion while keeping HttpClient reuse safe.
            services
                .AddHttpClient(Constants.HttpClientName, client =>
                {
                    client.BaseAddress = new Uri(clientOptions.BaseUrl ?? Constants.BaseUrl);
                })
                .AddHttpMessageHandler(() => new LoggingHandler());

            services.AddSingleton<INotionClient>(sp =>
            {
                var httpClientFactory = sp.GetRequiredService<System.Net.Http.IHttpClientFactory>();

                // Shallow-copy options so the factory-created HttpClient is used in RestClient.
                var options = new ClientOptions
                {
                    AuthToken = clientOptions.AuthToken,
                    BaseUrl = clientOptions.BaseUrl,
                    NotionVersion = clientOptions.NotionVersion,
                    HttpClient = httpClientFactory.CreateClient(Constants.HttpClientName)
                };

                return NotionClientFactory.Create(options);
            });

            return services;
        }
    }
}
