using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task CreateAsync()
        {
            var path = ApiEndpoints.PagesApiUrls.Create();

            var jsonData = await File.ReadAllTextAsync("data/pages/CreatePageResponse.json");


            Server.Given(CreatePostRequestBuilder(path))
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var newPage = new NewPage();
            newPage.AddProperty("Name", new TitlePropertyValue()
            {
                Title = new List<RichTextBase>()
                {
                    new RichTextText()
                    {
                        Text = new Text
                        {
                            Content = "Test"
                        }
                    }
                }
            });

            var page = await _client.CreateAsync(newPage);

            page.Id.Should().NotBeNullOrEmpty();
            page.Url.Should().NotBeNullOrEmpty();
            page.Properties.Should().HaveCount(1);
            page.Properties.First().Key.Should().Be("Name");
            page.IsArchived.Should().BeFalse();

        }

        [Fact]
        public async Task UpdatePropertiesAsync()
        {
            var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
            var path = ApiEndpoints.PagesApiUrls.UpdateProperties(pageId);

            var jsonData = await File.ReadAllTextAsync("data/pages/UpdatePagePropertiesResponse.json");

            Server.Given(CreatePatchRequestBuilder(path))
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var updatedProperties = new Dictionary<string, PropertyValue>()
            {
                { "In stock", new CheckboxPropertyValue() { Checkbox = true } }
            };

            var page = await _client.UpdatePropertiesAsync(pageId, updatedProperties);

            page.Id.Should().Be(pageId);
            page.Properties.Should().HaveCount(2);
            var updatedProperty = page.Properties.First(x => x.Key == "In stock");
            ((CheckboxPropertyValue)updatedProperty.Value).Checkbox.Should().BeTrue();
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
