using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Notion.Client;

namespace list_users
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new NotionClient(new ClientOptions
            {
                AuthToken = "<Token>"
            });

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();

            var factory = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole();
            });

            NotionClientLogging.ConfigureLogger(factory);

            var usersList = await client.Users.ListAsync();

            Console.WriteLine(usersList.Results.Count());
        }
    }
}
