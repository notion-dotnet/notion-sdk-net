using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests
{
    public class DatabasesClientTests : ApiTestBase
    {
        private readonly IDatabasesClient _client;

        public DatabasesClientTests()
        {
            _client = new DatabasesClient(new RestClient(ClientOptions));
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

        [Fact]
        public async Task DatabasePropertyObjectContainNameProperty()
        {
            var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
            var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
            var jsonData = await File.ReadAllTextAsync("data/databases/DatabasePropertyObjectContainNameProperty.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var database = await _client.RetrieveAsync(databaseId);

            foreach (var property in database.Properties)
            {
                property.Key.Should().Be(property.Value.Name);
            }
        }

        [Fact]
        public async Task DatabasePropertyObjectContainParentProperty()
        {
            var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
            var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
            var jsonData = await File.ReadAllTextAsync("data/databases/DatabasePropertyObjectContainParentProperty.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var database = await _client.RetrieveAsync(databaseId);

            database.Parent.Type.Should().Be(ParentType.PageId);
            database.Parent.Should().BeOfType<PageParent>();
            ((PageParent)database.Parent).PageId.Should().Be("649089db-8984-4051-98fb-a03593b852d8");
        }
    }
}
