using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

public class SearchClientTest : ApiTestBase
{
    private readonly SearchClient _client;

    public SearchClientTest()
    {
        _client = new SearchClient(new RestClient(ClientOptions));
    }

    [Fact]
    public async Task Search()
    {
        // Arrange
        var path = ApiEndpoints.SearchApiUrls.Search();
        var jsonData = await File.ReadAllTextAsync("data/search/SearchResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var searchParameters = new SearchRequest
        {
            Query = "External tasks",
            Sort = new SearchSort
            {
                Direction = SearchDirection.Ascending,
                Timestamp = "last_edited_time"
            }
        };

        // Act
        var searchResult = await _client.SearchAsync(searchParameters);

        // Assert
        var results = searchResult.Results;

        results.Should().SatisfyRespectively(
            obj =>
            {
                obj.Object.Should().Be(ObjectType.Database);

                var database = (Database)obj;
                database.Properties.Should().HaveCount(2);
            },
            obj =>
            {
                obj.Object.Should().Be(ObjectType.Page);

                var page = (Page)obj;
                page.InTrash.Should().BeFalse();
                page.Properties.Should().HaveCount(1);
                page.Parent.Should().BeAssignableTo<DatabaseParent>();
                ((DatabaseParent)page.Parent).DatabaseId.Should().Be("e6c6f8ff-c70e-4970-91ba-98f03e0d7fc6");
            }
        );
    }
}
