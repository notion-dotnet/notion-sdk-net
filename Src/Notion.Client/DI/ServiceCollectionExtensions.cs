using System;
using System.Diagnostics.CodeAnalysis;
using Notion.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotionClient(
            this IServiceCollection services,
            Action<ClientOptions> options)
        {
            services.AddSingleton<INotionClient, NotionClient>(_ =>
            {
                var clientOptions = new ClientOptions();
                options?.Invoke(clientOptions);

                return NotionClientFactory.Create(clientOptions);
            });

            return services;
        }
    }
}
