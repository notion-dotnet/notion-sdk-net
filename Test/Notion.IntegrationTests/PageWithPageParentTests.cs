using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageWithPageParentTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new ParentPageInput() { PageId = ParentPageId })
            .AddProperty("title",
                new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextTextInput { Text = new Text { Content = "Test Page Title" } }
                    }
                }).Build();

        _page = await Client.Pages.CreateAsync(pagesCreateParameters);
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task Update_Title_Of_Page()
    {
        // Arrange
        var updatePage = new PagesUpdateParameters()
        {
            Properties = new Dictionary<string, PropertyValue>
            {
                {
                    "title",
                    new TitlePropertyValue()
                    {
                        Title = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text() { Content = "Page Title Updated" } }
                        }
                    }
                }
            }
        };

        // Act
        var updatedPage = await Client.Pages.UpdateAsync(_page.Id, updatePage);

        // Assert
        var titleProperty = (ListPropertyItem)await Client.Pages.RetrievePagePropertyItemAsync(
            new RetrievePropertyItemParameters
            {
                PageId = updatedPage.Id,
                PropertyId = updatedPage.Properties["title"].Id
            }
        );

        titleProperty.Results.First().As<TitlePropertyItem>().Title.PlainText.Should().Be("Page Title Updated");
    }
}
