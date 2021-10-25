using System;
using Notion.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotionClient(this IServiceCollection services, Action<ClientOptions> options) 
        {
            services.AddSingleton<INotionClient, NotionClient>(sp => {
                var clientOptions = new ClientOptions();
                options?.Invoke(clientOptions);

                return NotionClientFactory.Create(clientOptions);
            });

            return services;
        }
    }
}
