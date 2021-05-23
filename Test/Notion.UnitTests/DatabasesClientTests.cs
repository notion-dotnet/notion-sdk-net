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