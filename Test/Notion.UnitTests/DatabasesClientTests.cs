using System.Threading.Tasks;
using Xunit;
using Notion.Client;

namespace Notion.UnitTests
{
    public class DatabasesClientTests
    {
        private readonly IDatabaseClient _client;

        public DatabasesClientTests()
        {
            var options = new ClientOptions() 
            {
                AuthToken = "<Token>"
            };

            _client = new DatabaseClient(new RestClient(options));
        }

        [Fact(Skip =  "Internal Testing Purpose")]
        public async Task ListDatabasesAsync()
        {
            var databasesList = await _client.ListAsync();
            Assert.NotNull(databasesList);
        }
    }
}