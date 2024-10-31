using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class DatabasesClientTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task QueryDatabase()
    {
        // Arrange
        var createdDatabase = await CreateDatabaseWithAPageAsync();

        // Act
        var response = await Client.Databases.QueryAsync(createdDatabase.Id, new DatabasesQueryParameters());

        // Assert
        response.Results.Should().NotBeNull();
        var page = response.Results.Should().ContainSingle().Subject.As<Page>();

        page.Properties["Name"].As<TitlePropertyValue>()
            .Title.Cast<RichTextText>().First()
            .Text.Content.Should().Be("Test Title");
    }

    private async Task<Database> CreateDatabaseWithAPageAsync()
    {
        var createDbRequest = new DatabasesCreateParameters
        {
            Title = new List<RichTextBaseInput>
            {
                new RichTextTextInput
                {
                    Text = new Text
                    {
                        Content = "Test List",
                        Link = null
                    }
                }
            },
            Properties = new Dictionary<string, IPropertySchema>
            {
                { "Name", new TitlePropertySchema { Title = new Dictionary<string, object>() } },
            },
            Parent = new ParentPageInput { PageId = _page.Id }
        };

        var createdDatabase = await Client.Databases.CreateAsync(createDbRequest);

        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new DatabaseParentInput { DatabaseId = createdDatabase.Id })
            .AddProperty("Name",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Test Title" } }
                    }
                })
            .Build();

        await Client.Pages.CreateAsync(pagesCreateParameters);

        return createdDatabase;
    }
}
