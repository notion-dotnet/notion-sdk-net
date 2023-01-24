using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class IBlocksClientTests : IntegrationTestBase
{
    [Fact]
    public async Task AppendChildrenAsync_AppendsBlocksGivenBlocks()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );

        var blocks = await Client.Blocks.AppendChildrenAsync(
            page.Id,
            new BlocksAppendChildrenParameters
            {
                Children = new List<IBlock>
                {
                    new BreadcrumbBlock { Breadcrumb = new BreadcrumbBlock.Data() },
                    new DividerBlock { Divider = new DividerBlock.Data() },
                    new TableOfContentsBlock { TableOfContents = new TableOfContentsBlock.Data() },
                    new CalloutBlock
                    {
                        Callout = new CalloutBlock.Info
                        {
                            RichText = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput { Text = new Text { Content = "Test" } }
                            }
                        }
                    }
                }
            }
        );

        blocks.Results.Should().HaveCount(4);

        // cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task UpdateBlockAsync_UpdatesGivenBlock()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );

        var blocks = await Client.Blocks.AppendChildrenAsync(
            page.Id,
            new BlocksAppendChildrenParameters
            {
                Children = new List<IBlock> { new BreadcrumbBlock { Breadcrumb = new BreadcrumbBlock.Data() } }
            }
        );

        var blockId = blocks.Results.First().Id;
        await Client.Blocks.UpdateAsync(blockId, new BreadcrumbUpdateBlock());

        blocks = await Client.Blocks.RetrieveChildrenAsync(page.Id);
        blocks.Results.Should().HaveCount(1);

        // cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Fact]
    public async Task DeleteAsync_DeleteBlockWithGivenId()
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );

        var blocks = await Client.Blocks.AppendChildrenAsync(
            page.Id,
            new BlocksAppendChildrenParameters
            {
                Children = new List<IBlock>
                {
                    new DividerBlock { Divider = new DividerBlock.Data() },
                    new TableOfContentsBlock { TableOfContents = new TableOfContentsBlock.Data() }
                }
            }
        );

        blocks.Results.Should().HaveCount(2);

        // cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    [Theory]
    [MemberData(nameof(BlockData))]
    public async Task UpdateAsync_UpdatesGivenBlock(
        IBlock block, IUpdateBlock updateBlock, Action<IBlock, INotionClient> assert)
    {
        var page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput { PageId = ParentPageId }
            ).Build()
        );

        var blocks = await Client.Blocks.AppendChildrenAsync(
            page.Id,
            new BlocksAppendChildrenParameters { Children = new List<IBlock> { block } }
        );

        var blockId = blocks.Results.First().Id;
        await Client.Blocks.UpdateAsync(blockId, updateBlock);

        blocks = await Client.Blocks.RetrieveChildrenAsync(page.Id);
        blocks.Results.Should().HaveCount(1);

        var updatedBlock = blocks.Results.First();

        assert.Invoke(updatedBlock, Client);

        // cleanup
        await Client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters { Archived = true });
    }

    private static IEnumerable<object[]> BlockData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new BookmarkBlock
                {
                    Bookmark = new BookmarkBlock.Info
                    {
                        Url = "https://developers.notion.com/reference/rich-text",
                        Caption = new List<RichTextBase>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Notion API" } }
                        }
                    }
                },
                new BookmarkUpdateBlock
                {
                    Bookmark = new BookmarkUpdateBlock.Info
                    {
                        Url = "https://github.com/notion-dotnet/notion-sdk-net",
                        Caption = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Github" } }
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    var updatedBlock = (BookmarkBlock)block;
                    Assert.Equal("https://github.com/notion-dotnet/notion-sdk-net", updatedBlock.Bookmark.Url);
                    Assert.Equal("Github", updatedBlock.Bookmark.Caption.OfType<RichTextText>().First().Text.Content);
                })
            },
            new object[]
            {
                new EquationBlock { Equation = new EquationBlock.Info { Expression = "e=mc^3" } },
                new EquationUpdateBlock { Equation = new EquationUpdateBlock.Info { Expression = "e=mc^2" } },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    var updatedBlock = (EquationBlock)block;
                    Assert.Equal("e=mc^2", updatedBlock.Equation.Expression);
                })
            },
            new object[]
            {
                new DividerBlock { Divider = new DividerBlock.Data() }, new DividerUpdateBlock(), new Action<IBlock>(
                    block =>
                    {
                        Assert.NotNull(block);
                        _ = Assert.IsType<DividerBlock>(block);
                    })
            },
            new object[]
            {
                new AudioBlock
                {
                    Audio = new ExternalFile
                    {
                        External = new ExternalFile.Info
                        {
                            Url = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3"
                        }
                    }
                },
                new AudioUpdateBlock
                {
                    Audio = new ExternalFileInput
                    {
                        External = new ExternalFileInput.Data
                        {
                            Url = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-3.mp3"
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    block.Should().NotBeNull();
            
                    block.Should().BeOfType<AudioBlock>().Subject
                        .Audio.Should().BeOfType<ExternalFile>().Subject
                        .External.Url.Should().Be("https://www.soundhelix.com/examples/mp3/SoundHelix-Song-3.mp3");
                })
            },
            new object[]
            {
                new TableOfContentsBlock { TableOfContents = new TableOfContentsBlock.Data() },
                new TableOfContentsUpdateBlock(), new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    _ = Assert.IsType<TableOfContentsBlock>(block);
                })
            },
            new object[]
            {
                new CalloutBlock
                {
                    Callout = new CalloutBlock.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Test" } }
                        }
                    }
                },
                new CalloutUpdateBlock
                {
                    Callout = new CalloutUpdateBlock.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Test 2" } }
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var calloutBlock = Assert.IsType<CalloutBlock>(block);
            
                    Assert.Equal("Test 2", calloutBlock.Callout.RichText.OfType<RichTextText>().First().Text.Content);
                })
            },
            new object[]
            {
                new QuoteBlock
                {
                    Quote = new QuoteBlock.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Test" } }
                        }
                    }
                },
                new QuoteUpdateBlock
                {
                    Quote = new QuoteUpdateBlock.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Test 2" } }
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var quoteBlock = Assert.IsType<QuoteBlock>(block);
            
                    Assert.Equal("Test 2", quoteBlock.Quote.RichText.OfType<RichTextText>().First().Text.Content);
                })
            },
            new object[]
            {
                new ImageBlock
                {
                    Image = new ExternalFile
                    {
                        External = new ExternalFile.Info
                        {
                            Url = "https://zephoria.com/wp-content/uploads/2014/08/online-community.jpg"
                        }
                    }
                },
                new ImageUpdateBlock
                {
                    Image = new ExternalFileInput
                    {
                        External = new ExternalFileInput.Data
                        {
                            Url
                                = "https://www.iaspaper.net/wp-content/uploads/2017/09/TNEA-Online-Application.jpg"
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var imageBlock = Assert.IsType<ImageBlock>(block);
                    var imageFile = Assert.IsType<ExternalFile>(imageBlock.Image);
            
                    Assert.Equal("https://www.iaspaper.net/wp-content/uploads/2017/09/TNEA-Online-Application.jpg",
                        imageFile.External.Url);
                })
            },
            new object[]
            {
                new EmbedBlock
                {
                    Embed = new EmbedBlock.Info
                    {
                        Url = "https://zephoria.com/wp-content/uploads/2014/08/online-community.jpg"
                    }
                },
                new EmbedUpdateBlock
                {
                    Embed = new EmbedUpdateBlock.Info
                    {
                        Url = "https://www.iaspaper.net/wp-content/uploads/2017/09/TNEA-Online-Application.jpg"
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var embedBlock = Assert.IsType<EmbedBlock>(block);
            
                    Assert.Equal("https://www.iaspaper.net/wp-content/uploads/2017/09/TNEA-Online-Application.jpg",
                        embedBlock.Embed.Url);
                })
            },
            new object[]
            {
                new TemplateBlock
                {
                    Template = new TemplateBlock.Data
                    {
                        RichText = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "Test Template" } }
                        },
                        Children = new List<ITemplateChildrenBlock>
                        {
                            new EmbedBlock
                            {
                                Embed = new EmbedBlock.Info
                                {
                                    Url
                                        = "https://zephoria.com/wp-content/uploads/2014/08/online-community.jpg"
                                }
                            }
                        }
                    }
                },
                new TemplateUpdateBlock
                {
                    Template = new TemplateUpdateBlock.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = "Test Template 2" } }
                        }
                    }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var templateBlock = Assert.IsType<TemplateBlock>(block);
            
                    Assert.Single(templateBlock.Template.RichText);
                    Assert.Null(templateBlock.Template.Children);
            
                    Assert.Equal("Test Template 2",
                        templateBlock.Template.RichText.OfType<RichTextText>().First().Text.Content);
                })
            },
            new object[]
            {
                new LinkToPageBlock
                {
                    LinkToPage = new PageParent
                    {
                        Type = ParentType.PageId,
                        PageId = "533578e3edf14c0a91a9da6b09bac3ee"
                    }
                },
                new LinkToPageUpdateBlock
                {
                    LinkToPage = new ParentPageInput { PageId = "3c357473a28149a488c010d2b245a589" }
                },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    Assert.NotNull(block);
                    var linkToPageBlock = Assert.IsType<LinkToPageBlock>(block);
            
                    var pageParent = Assert.IsType<PageParent>(linkToPageBlock.LinkToPage);
            
                    // TODO: Currently the api doesn't allow to update the link_to_page block type
                    // This will change to updated ID once api start to support
                    Assert.Equal(Guid.Parse("533578e3edf14c0a91a9da6b09bac3ee"), Guid.Parse(pageParent.PageId));
                })
            },
            new object[]
            {
                new TableBlock
                {
                    Table = new TableBlock.Info
                    {
                        TableWidth = 1,
                        Children = new[]
                        {
                            new TableRowBlock
                            {
                                TableRow = new TableRowBlock.Info
                                {
                                    Cells = new[]
                                    {
                                        new[] { new RichTextText { Text = new Text { Content = "Data" } } }
                                    }
                                }
                            }
                        }
                    }
                },
                new TableUpdateBlock { Table = new TableUpdateBlock.Info { HasColumnHeader = false } },
                new Action<IBlock, INotionClient>((block, client) =>
                {
                    var tableBlock = block.Should().NotBeNull().And.BeOfType<TableBlock>().Subject;
                    tableBlock.HasChildren.Should().BeTrue();

                    var children = client.Blocks.RetrieveChildrenAsync(tableBlock.Id).GetAwaiter().GetResult();

                    children.Results.Should().ContainSingle()
                        .Subject.Should().BeOfType<TableRowBlock>()
                        .Subject.TableRow.Cells.Should().ContainSingle()
                        .Subject.Should().ContainSingle()
                        .Subject.Should().BeOfType<RichTextText>()
                        .Subject.Text.Content.Should().Be("Data");
                })
            }
        };
    }
}
