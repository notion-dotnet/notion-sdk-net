using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PageContentTests : IntegrationTestBase
{
    [Fact]
    public async Task CreateAsync_WithContent_CreatesPageWithBlocks()
    {
        var page = await Client.Pages.CreateAsync(new PagesCreateParameters
        {
            Parent = new PageParentRequest { PageId = ParentPageId },
            Properties = new Dictionary<string, PropertyValue>
            {
                {
                    "title",
                    new TitlePropertyValue
                    {
                        Title = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "Page created with content" } }
                        }
                    }
                }
            },
            Content = new List<IBlock>
            {
                new ParagraphBlockRequest
                {
                    Paragraph = new ParagraphBlockRequest.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Written through content" } }
                        }
                    }
                }
            }
        });

        try
        {
            var markdown = await Client.Pages.RetrieveAsMarkdownAsync(
                new RetrievePageAsMarkdownRequest { PageId = page.Id });

            markdown.Markdown.Should().Contain("Written through content");
        }
        finally
        {
            await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { InTrash = true });
        }
    }
}
