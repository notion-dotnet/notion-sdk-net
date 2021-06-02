using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests
{
    public class DatabasesClientTests
    {
        private readonly IDatabasesClient _client;

        public DatabasesClientTests()
        {
            var options = new ClientOptions()
            {
                AuthToken = "<Token>"
            };

            _client = new DatabasesClient(new RestClient(options));
        }

        [Fact(Skip = "Internal Testing Purpose")]
        public async Task ListDatabasesAsync()
        {
            var databasesList = await _client.ListAsync();
            Assert.NotNull(databasesList);
        }

        [Fact(Skip = "Internal Testing Purpose")]
        public async Task RetrieveDatabaseAsync()
        {
            var databaseId = "";
            var database = await _client.RetrieveAsync(databaseId);
            Assert.NotNull(database);
        }

        [Fact(Skip = "Internal Testing Purpose")]
        public async Task QueryAsync()
        {
            var databaseId = "";
            var databasesQueryParameters = new DatabasesQueryParameters { };
            var pagesList = await _client.QueryAsync(databaseId, databasesQueryParameters);

            Assert.NotNull(pagesList);
        }
    }
}
