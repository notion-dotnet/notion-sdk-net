using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class SearchClientTests : IntegrationTestBase
{
    [Fact]
    public async Task Search_With_InTrash_Only_Filter_Returns_Only_Trashed_Pages()
    {
        var response = await Client.Search.SearchAsync(new SearchRequest
        {
            Filter = new SearchFilter { InTrash = true }, PageSize = 10
        });

        response.Results.Should().NotBeNull();
        response.Results.OfType<Page>().Should().OnlyContain(p => p.InTrash);
    }

    [Fact]
    public async Task Search_With_Object_Filter_And_InTrash_False_Returns_Only_Active_Pages()
    {
        var response = await Client.Search.SearchAsync(new SearchRequest
        {
            Filter = new SearchFilter { Value = SearchObjectType.Page, InTrash = false }, PageSize = 10
        });

        response.Results.Should().NotBeNull();
        response.Results.Should().AllBeOfType<Page>();
        response.Results.OfType<Page>().Should().OnlyContain(p => !p.InTrash);
    }

    [Fact]
    public async Task Search_With_Object_Filter_Only_Still_Works()
    {
        var response = await Client.Search.SearchAsync(new SearchRequest
        {
            Filter = new SearchFilter { Value = SearchObjectType.DataSource }, PageSize = 10
        });

        response.Results.Should().NotBeNull();
    }
}
