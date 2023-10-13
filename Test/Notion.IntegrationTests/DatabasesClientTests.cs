using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class DatabasesClientTests : IntegrationTestBase, IDisposable
{
    private readonly Page _page;

    public DatabasesClientTests()
    {
        _page = Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        ).Result;
    }

    public void Dispose()
    {
        Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { Archived = true }).Wait();
    }

    [Fact]
    public async Task QueryDatabase()
    {
        // Arrange
        var createdDatabase = await CreateDatabaseWithAPageAsync();


        // Act
        var response = await Client.Databases.QueryAsync(createdDatabase.Id, new DatabasesQueryParameters());

        // Assert
        Assert.NotNull(response.Results);
        Assert.Single(response.Results);
        var page = response.Results.Cast<Page>().First();
        var title = page.Properties["Name"] as TitlePropertyValue;
        Assert.Equal("Test Title", (title!.Title.Cast<RichTextText>().First()).Text.Content);
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
