using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests
{
    public class PagesClientTests : ApiTestBase
    {
        private readonly IPagesClient _client;

        public PagesClientTests()
        {
            _client = new PagesClient(new RestClient(ClientOptions));
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
            var path = ApiEndpoints.PagesApiUrls.Retrieve(pageId);
            var jsonData = await File.ReadAllTextAsync("data/pages/PageObjectShouldHaveUrlPropertyResponse.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var page = await _client.RetrieveAsync(pageId);

            page.Url.Should().Be("https://www.notion.so/Avocado-251d2b5f268c4de2afe9c71ff92ca95c");
            page.Id.Should().Be(pageId);
            page.Parent.Type.Should().Be(ParentType.DatabaseId);
            ((DatabaseParent)page.Parent).DatabaseId.Should().Be("48f8fee9-cd79-4180-bc2f-ec0398253067");
            page.IsArchived.Should().BeFalse();

        }

        [Fact]
        public async Task PageObjectShouldHaveUrlProperty()
        {
            var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
            var path = ApiEndpoints.PagesApiUrls.Retrieve(pageId);
            var jsonData = await File.ReadAllTextAsync("data/pages/PageObjectShouldHaveUrlPropertyResponse.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var page = await _client.RetrieveAsync(pageId);

            page.Url.Should().Be("https://www.notion.so/Avocado-251d2b5f268c4de2afe9c71ff92ca95c");

        }
    }
}
