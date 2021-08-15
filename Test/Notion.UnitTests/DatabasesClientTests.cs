using System.Collections.Generic;
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

        [Fact]
        public async Task ListDatabasesAsync()
        {
            var path = ApiEndpoints.DatabasesApiUrls.List();
            var jsonData = await File.ReadAllTextAsync("data/databases/DatabasesListResponse.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var databases = await _client.ListAsync();

            databases.Results.Should().HaveCount(3);

            foreach (var database in databases.Results)
            {
                database.Parent.Should().BeAssignableTo<IDatabaseParent>();
                foreach (var property in database.Properties)
                {
                    property.Key.Should().Be(property.Value.Name);
                }
            }
        }

        [Fact]
        public async Task QueryAsync()
        {
            var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
            var path = ApiEndpoints.DatabasesApiUrls.Query(databaseId);
            var jsonData = await File.ReadAllTextAsync("data/databases/DatabasesQueryResponse.json");

            Server.Given(CreatePostRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var databasesQueryParams = new DatabasesQueryParameters
            {
                Filter = new CompoundFilter
                {
                    Or = new List<Filter> {
                        new CheckboxFilter(
                            "In stock",
                            true
                        ),
                        new NumberFilter(
                            "Cost of next trip",
                            greaterThanOrEqualTo: 2
                        )
                    },
                },
                Sorts = new List<Sort>
                {
                    new Sort
                    {
                        Property = "Last ordered",
                        Direction = Direction.Ascending
                    }
                }
            };

            var pagesPaginatedList = await _client.QueryAsync(databaseId, databasesQueryParams);

            pagesPaginatedList.Results.Should().ContainSingle();

            foreach (var page in pagesPaginatedList.Results)
            {
                page.Parent.Should().BeAssignableTo<IPageParent>();
                page.Object.Should().Be(ObjectType.Page);
            }
        }

        [Fact]
        public async Task RetrieveDatabaseAsync()
        {
            var databaseId = "f0212efc-caf6-4afc-87f6-1c06f1dfc8a1";
            var path = ApiEndpoints.DatabasesApiUrls.Retrieve(databaseId);
            var jsonData = await File.ReadAllTextAsync("data/databases/DatabaseRetrieveResponse.json");

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
            foreach (var property in database.Properties)
            {
                property.Key.Should().Be(property.Value.Name);
            }
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
