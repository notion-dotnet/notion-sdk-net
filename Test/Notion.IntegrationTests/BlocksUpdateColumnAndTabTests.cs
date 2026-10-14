using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class BlocksUpdateColumnAndTabTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task UpdateAsync_WithColumnUpdateBlock_ChangesWidthRatio()
    {
        var appended = await Client.Blocks.AppendChildrenAsync(
            new BlockAppendChildrenRequest
            {
                BlockId = _page.Id,
                Children = new List<IBlockObjectRequest>
                {
                    new ColumnListBlockRequest
                    {
                        ColumnList = new ColumnListBlockRequest.Info
                        {
                            Children = new List<ColumnBlockRequest>
                            {
                                CreateColumn("Left", 0.5),
                                CreateColumn("Right", 0.5)
                            }
                        }
                    }
                }
            });

        var columns = await Client.Blocks.RetrieveChildrenAsync(
            new BlockRetrieveChildrenRequest { BlockId = appended.Results.Single().Id });
        var firstColumnId = columns.Results.First().Id;

        await Client.Blocks.UpdateAsync(
            firstColumnId,
            new ColumnUpdateBlock { Column = new ColumnUpdateBlock.Info { WidthRatio = 0.25 } });

        var updated = await Client.Blocks.RetrieveAsync(firstColumnId);

        updated.Should().BeOfType<ColumnBlock>().Which.Column.WidthRatio.Should().Be(0.25);
    }

    [Fact]
    public async Task UpdateAsync_WithTabUpdateBlock_Succeeds()
    {
        var appended = await Client.Blocks.AppendChildrenAsync(
            new BlockAppendChildrenRequest
            {
                BlockId = _page.Id,
                Children = new List<IBlockObjectRequest>
                {
                    new TabBlockRequest
                    {
                        Tab = new TabBlockRequest.Data
                        {
                            Children = new List<ParagraphBlockRequest>
                            {
                                new ParagraphBlockRequest
                                {
                                    Paragraph = new ParagraphBlockRequest.Info
                                    {
                                        RichText = new List<RichTextBaseInput>
                                        {
                                            new RichTextTextInput { Text = new Text { Content = "Tab 1" } }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        var tabId = appended.Results.Single().Id;

        var updated = await Client.Blocks.UpdateAsync(tabId, new TabUpdateBlock());

        updated.Should().BeOfType<TabBlock>();
        updated.Id.Should().Be(tabId);
    }

    private static ColumnBlockRequest CreateColumn(string text, double widthRatio)
    {
        return new ColumnBlockRequest
        {
            Column = new ColumnBlockRequest.Info
            {
                WidthRatio = widthRatio,
                Children = new List<IColumnChildrenBlockRequest>
                {
                    new ParagraphBlockRequest
                    {
                        Paragraph = new ParagraphBlockRequest.Info
                        {
                            RichText = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput { Text = new Text { Content = text } }
                            }
                        }
                    }
                }
            }
        };
    }
}
