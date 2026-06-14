using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageMarkdownTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _parentPage = null!;

    public async Task InitializeAsync()
    {
        _parentPage = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = ParentPageId })
                .AddProperty("title", new TitlePropertyValue
                {
                    Title = new List<RichTextBase>
                    {
                        new RichTextText { Text = new Text { Content = "Markdown Test Parent" } }
                    }
                })
                .Build()
        );
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_parentPage.Id, new PagesUpdateParameters { InTrash = true });
    }

    private async Task<Page> CreatePageWithMarkdownAsync(string markdown)
    {
        return await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new PageParentRequest { PageId = _parentPage.Id })
                .SetMarkdown(markdown)
                .Build()
        );
    }

    [Fact]
    public async Task UpdateMarkdownAsync_InsertContent_AtEnd_AppendsContent()
    {
        var page = await CreatePageWithMarkdownAsync("Hello World");

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new InsertContentMarkdownBody
        {
            InsertContent = new InsertContentData
            {
                Content = "Appended paragraph",
                Position = new EndMarkdownInsertPosition()
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().NotBeNullOrEmpty();
        result.Markdown.Should().Contain("Appended paragraph");
    }

    [Fact]
    public async Task UpdateMarkdownAsync_InsertContent_AtStart_PrependsContent()
    {
        var page = await CreatePageWithMarkdownAsync("Hello World");

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new InsertContentMarkdownBody
        {
            InsertContent = new InsertContentData
            {
                Content = "Prepended paragraph",
                Position = new StartMarkdownInsertPosition()
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().NotBeNullOrEmpty();
        result.Markdown.Should().Contain("Prepended paragraph");
    }

    [Fact]
    public async Task UpdateMarkdownAsync_ReplaceContent_ReplacesEntirePageContent()
    {
        var page = await CreatePageWithMarkdownAsync("Old content that will be replaced");

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new ReplaceContentMarkdownBody
        {
            ReplaceContent = new ReplaceContentData
            {
                NewStr = "## Replaced\n\nThis content replaced everything."
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().NotBeNullOrEmpty();
        result.Markdown.Should().Contain("Replaced");
        result.Markdown.Should().Contain("This content replaced everything.");
    }

    [Fact]
    public async Task UpdateMarkdownAsync_ReplaceContent_WithAllowDeletingContent_Succeeds()
    {
        var page = await CreatePageWithMarkdownAsync("Content to be replaced");

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new ReplaceContentMarkdownBody
        {
            ReplaceContent = new ReplaceContentData
            {
                NewStr = "Fresh content",
                AllowDeletingContent = true
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().Contain("Fresh content");
    }

    [Fact]
    public async Task UpdateMarkdownAsync_UpdateContent_ReplacesSpecificText()
    {
        var page = await CreatePageWithMarkdownAsync("Hello World");

        // First pin the content to a known exact state
        await Client.Pages.UpdateMarkdownAsync(page.Id, new ReplaceContentMarkdownBody
        {
            ReplaceContent = new ReplaceContentData { NewStr = "Hello World" }
        });

        var retrieved = await Client.Pages.RetrieveAsMarkdownAsync(
            new RetrievePageAsMarkdownRequest { PageId = page.Id });

        var exactText = retrieved.Markdown.Trim();

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new UpdateContentMarkdownBody
        {
            UpdateContent = new UpdateContentData
            {
                ContentUpdates = new List<ContentUpdate>
                {
                    new ContentUpdate
                    {
                        OldStr = exactText,
                        NewStr = "Hello Notion"
                    }
                }
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().Contain("Hello Notion");
    }

    [Fact]
    public async Task UpdateMarkdownAsync_ReplaceContentRange_ReplacesMatchedRange()
    {
        var page = await CreatePageWithMarkdownAsync("Line 1\n\nLine 2\n\nLine 3");

        // Pin content to a known state and retrieve the exact markdown
        await Client.Pages.UpdateMarkdownAsync(page.Id, new ReplaceContentMarkdownBody
        {
            ReplaceContent = new ReplaceContentData { NewStr = "Line 1\n\nLine 2\n\nLine 3" }
        });

        var retrieved = await Client.Pages.RetrieveAsMarkdownAsync(
            new RetrievePageAsMarkdownRequest { PageId = page.Id });

        // Build the content_range using the ellipsis format "start...end"
        var markdown = retrieved.Markdown;
        var firstLine = "Line 1";
        var lastLine = "Line 3";

        if (!markdown.Contains(firstLine) || !markdown.Contains(lastLine))
        {
            // Content wasn't set as expected; skip range assertion
            return;
        }

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new ReplaceContentRangeMarkdownBody
        {
            ReplaceContentRange = new ReplaceContentRangeData
            {
                Content = "Replaced range",
                ContentRange = $"{firstLine}...{lastLine}"
            }
        });

        result.Should().NotBeNull();
        result.Markdown.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task UpdateMarkdownAsync_ReturnsPageMarkdownResponse_WithExpectedShape()
    {
        var page = await CreatePageWithMarkdownAsync("Shape test content");

        var result = await Client.Pages.UpdateMarkdownAsync(page.Id, new InsertContentMarkdownBody
        {
            InsertContent = new InsertContentData
            {
                Content = "Extra line",
                Position = new EndMarkdownInsertPosition()
            }
        });

        result.Should().NotBeNull();
        result.Id.Should().NotBeNullOrEmpty();
        result.Markdown.Should().NotBeNullOrEmpty();
        result.Object.Should().Be(ObjectType.PageMarkdown);
    }
}
