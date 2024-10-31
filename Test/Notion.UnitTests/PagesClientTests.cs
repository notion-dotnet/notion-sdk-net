using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

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
        page.InTrash.Should().BeFalse();
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

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = "3c357473-a281-49a4-88c0-10d2b245a589" })
            .AddProperty(
                "Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase> { new RichTextText { Text = new Text { Content = "Test" } } }
                }
            ).Build();

        var page = await _client.CreateAsync(pagesCreateParameters);

        page.Id.Should().NotBeNullOrEmpty();
        page.Url.Should().NotBeNullOrEmpty();
        page.Properties.Should().HaveCount(1);
        page.Properties.First().Key.Should().Be("Name");
        page.InTrash.Should().BeFalse();
        page.Parent.Should().NotBeNull();
        ((DatabaseParent)page.Parent).DatabaseId.Should().Be("3c357473-a281-49a4-88c0-10d2b245a589");
    }

    [Fact]
    public async Task UpdatePropertiesAsync()
    {
        var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
        var propertyId = "{>U;";
        var path = ApiEndpoints.PagesApiUrls.UpdateProperties(pageId);

        var jsonData = await File.ReadAllTextAsync("data/pages/UpdatePagePropertiesResponse.json");

        Server.Given(CreatePatchRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        Server.Given(CreateGetRequestBuilder(ApiEndpoints.PagesApiUrls.RetrievePropertyItem(pageId, propertyId)))
            .RespondWith(
                Response.Create().WithStatusCode(200)
                    .WithBody(
                        "{\"object\":\"property_item\",\"id\":\"{>U;\",\"type\":\"checkbox\",\"checkbox\":true}"));

        var updatedProperties = new Dictionary<string, PropertyValue>
        {
            { "In stock", new CheckboxPropertyValue { Checkbox = true } }
        };

        var page = await _client.UpdatePropertiesAsync(pageId, updatedProperties);

        page.Id.Should().Be(pageId);
        page.Properties.Should().HaveCount(2);
        var updatedProperty = page.Properties.First(x => x.Key == "In stock");

        var checkboxPropertyValue = (CheckboxPropertyItem)await _client.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedProperty.Value.Id
            });

        checkboxPropertyValue.Checkbox.Should().BeTrue();
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

    [Fact]
    public async Task UpdatePageAsync()
    {
        var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
        var propertyId = "{>U;";
        var path = ApiEndpoints.PagesApiUrls.UpdateProperties(pageId);

        var jsonData = await File.ReadAllTextAsync("data/pages/UpdatePagePropertiesResponse.json");

        Server.Given(CreatePatchRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        Server.Given(CreateGetRequestBuilder(ApiEndpoints.PagesApiUrls.RetrievePropertyItem(pageId, propertyId)))
            .RespondWith(
                Response.Create().WithStatusCode(200)
                    .WithBody(
                        "{\"object\":\"property_item\",\"id\":\"{>U;\",\"type\":\"checkbox\",\"checkbox\":true}"));

        var pagesUpdateParameters = new PagesUpdateParameters
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                { "In stock", new CheckboxPropertyValue { Checkbox = true } }
            }
        };

        var page = await _client.UpdateAsync(pageId, pagesUpdateParameters);

        page.Id.Should().Be(pageId);
        page.InTrash.Should().BeFalse();
        page.Properties.Should().HaveCount(2);
        var updatedProperty = page.Properties.First(x => x.Key == "In stock");

        var checkboxPropertyValue = (CheckboxPropertyItem)await _client.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedProperty.Value.Id
            });

        checkboxPropertyValue.Checkbox.Should().BeTrue();
    }

    [Fact]
    public async Task TrashPageAsync()
    {
        var pageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
        var propertyId = "{>U;";

        var path = ApiEndpoints.PagesApiUrls.UpdateProperties(pageId);

        var jsonData = await File.ReadAllTextAsync("data/pages/TrashPageResponse.json");

        Server.Given(CreatePatchRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        Server.Given(CreateGetRequestBuilder(ApiEndpoints.PagesApiUrls.RetrievePropertyItem(pageId, propertyId)))
            .RespondWith(
                Response.Create().WithStatusCode(200)
                    .WithBody(
                        "{\"object\":\"property_item\",\"id\":\"{>U;\",\"type\":\"checkbox\",\"checkbox\":true}"));

        var pagesUpdateParameters = new PagesUpdateParameters
        {
            InTrash = true,
            Properties = new Dictionary<string, PropertyValue>
            {
                { "In stock", new CheckboxPropertyValue { Checkbox = true } }
            }
        };

        var page = await _client.UpdateAsync(pageId, pagesUpdateParameters);

        page.Id.Should().Be(pageId);
        page.InTrash.Should().BeTrue();
        page.Properties.Should().HaveCount(3);
        var updatedProperty = page.Properties.First(x => x.Key == "In stock");

        var checkboxPropertyValue = (CheckboxPropertyItem)await _client.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = page.Id,
                PropertyId = updatedProperty.Value.Id
            });

        checkboxPropertyValue.Checkbox.Should().BeTrue();
    }

    [Fact]
    public async Task CreateAsync_Throws_ArgumentNullException_When_Parameter_Is_Null()
    {
        Func<Task> act = async () => await _client.CreateAsync(null);

        (await act.Should().ThrowAsync<ArgumentNullException>()).And.ParamName.Should().Be("pagesCreateParameters");
    }

    [Fact]
    public async Task CreateAsync_Throws_ArgumentNullException_When_Parent_Is_Missing()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder.Create(null).Build();

        Func<Task> act = async () => await _client.CreateAsync(pagesCreateParameters);

        (await act.Should().ThrowAsync<ArgumentNullException>()).And.ParamName.Should().Be("Parent");
    }

    [Fact]
    public async Task CreateAsync_Throws_ArgumentNullException_When_Properties_Is_Missing()
    {
        var pagesCreateParameters = new PagesCreateParameters
        {
            Parent = new ParentPageInput { PageId = "3c357473-a281-49a4-88c0-10d2b245a589" },
            Properties = null
        };

        Func<Task> act = async () => await _client.CreateAsync(pagesCreateParameters);

        (await act.Should().ThrowAsync<ArgumentNullException>()).And.ParamName.Should().Be("Properties");
    }
}
