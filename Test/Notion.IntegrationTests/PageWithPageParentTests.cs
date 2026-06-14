using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;
using Xunit.Abstractions;

namespace Notion.IntegrationTests;

public class PageWithPageParentTests : IntegrationTestBase, IAsyncLifetime
{
    private readonly ITestOutputHelper _output;
    private Page _page = null!;

    public PageWithPageParentTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public async Task InitializeAsync()
    {
        var pagesCreateParameters = PagesCreateParametersBuilder
            .Create(new PageParentRequest() { PageId = ParentPageId })
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

    [Fact]
    public async Task CreateAsync_WithPageEndPosition_CreatesPageSuccessfully()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "End Position Page" } }
                    }
                })
                .SetPosition(new PageEndPosition())
                .Build()
        );

        page.Should().NotBeNull();
        page.Parent.Should().BeOfType<PageParent>()
            .Which.PageId.Should().Be(_page.Id);
    }

    [Fact]
    public async Task CreateAsync_WithPageStartPosition_CreatesPageSuccessfully()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Start Position Page" } }
                    }
                })
                .SetPosition(new PageStartPosition())
                .Build()
        );

        page.Should().NotBeNull();
        page.Parent.Should().BeOfType<PageParent>()
            .Which.PageId.Should().Be(_page.Id);
    }

    [Fact]
    public async Task CreateAsync_WithAfterBlockPosition_CreatesPageAfterSibling()
    {
        // Create a sibling page first to use as the anchor
        var sibling = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Sibling Page" } }
                    }
                })
                .SetPosition(new PageEndPosition())
                .Build()
        );

        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "After Sibling Page" } }
                    }
                })
                .SetPosition(new AfterBlockPagePosition
                {
                    AfterBlock = new AfterBlockReference { Id = sibling.Id }
                })
                .Build()
        );

        page.Should().NotBeNull();
        page.Parent.Should().BeOfType<PageParent>()
            .Which.PageId.Should().Be(_page.Id);
    }

    [Fact]
    public async Task CreateAsync_WithNoneTemplate_CreatesPageSuccessfully()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "No Template Page" } }
                    }
                })
                .SetTemplate(new NonePageTemplate())
                .Build()
        );

        page.Should().NotBeNull();
        page.Parent.Should().BeOfType<PageParent>()
            .Which.PageId.Should().Be(_page.Id);
    }

    [Fact]
    public async Task UpdateAsync_WithEraseContent_ClearsPageContent()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .SetMarkdown("# Heading\n\nSome content to erase.")
                .Build()
        );

        var updated = await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
        {
            EraseContent = true
        });

        updated.Should().NotBeNull();
        updated.Id.Should().Be(page.Id);

        var markdown = await Client.Pages.RetrieveAsMarkdownAsync(
            new RetrievePageAsMarkdownRequest { PageId = page.Id });

        // After erase_content the page markdown should be empty or very minimal
        markdown.Markdown.Should().NotContain("Some content to erase.");
    }

    [Fact]
    public async Task UpdateAsync_WithIsLocked_LocksPage()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _page.Id })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Page To Lock" } }
                    }
                })
                .Build()
        );

        // Lock the page
        var locked = await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
        {
            IsLocked = true
        });

        locked.Should().NotBeNull();

        // Unlock for cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
        {
            IsLocked = false,
            InTrash = true
        });
    }
}
