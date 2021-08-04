using System.IO;
using System.Threading.Tasks;
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

            Assert.Equal("https://www.notion.so/Avocado-251d2b5f268c4de2afe9c71ff92ca95c", page.Url);
        }
    }
}
