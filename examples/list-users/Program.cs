using System;
using System.Linq;
using System.Threading.Tasks;
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

            var usersList = await client.Users.ListAsync();

            Console.WriteLine(usersList.Results.Count());
        }
    }
}
