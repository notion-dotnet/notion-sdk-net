using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests
{
    public class IBlocksClientTests
    {
        private readonly INotionClient _client;

        public IBlocksClientTests()
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };

            _client = NotionClientFactory.Create(options);
        }

        [Fact]
        public async Task AppendChildrenAsync_AppendsBlocksGivenBlocks()
        {
            var pageParentId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new ParentPageInput()
                    {
                        PageId = pageParentId
                    }
                ).Build()
            );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<IBlock>()
                    {
                        new BreadcrumbBlock
                        {
                            Breadcrumb = new BreadcrumbBlock.Data()
                        },
                        new DividerBlock
                        {
                            Divider = new DividerBlock.Data()
                        },
                        new TableOfContentsBlock
                        {
                            TableOfContents = new TableOfContentsBlock.Data()
                        },
                        new CalloutBlock
                        {
                            Callout = new CalloutBlock.Info
                            {
                                Text = new List<RichTextBaseInput> {
                                    new RichTextTextInput
                                    {
                                        Text = new Text
                                        {
                                            Content = "Test"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            );

            blocks.Results.Should().HaveCount(4);

            // cleanup
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Fact]
        public async Task UpdateBlockAsync_UpdatesGivenBlock()
        {
            var pageParentId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                            PagesCreateParametersBuilder.Create(
                                new ParentPageInput()
                                {
                                    PageId = pageParentId
                                }
                            ).Build()
                        );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<IBlock>()
                    {
                        new BreadcrumbBlock
                        {
                            Breadcrumb = new BreadcrumbBlock.Data()
                        }
                    }
                }
            );

            var blockId = blocks.Results.First().Id;
            await _client.Blocks.UpdateAsync(blockId, new BreadcrumbUpdateBlock());

            blocks = await _client.Blocks.RetrieveChildrenAsync(page.Id);
            blocks.Results.Should().HaveCount(1);

            // cleanup
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Fact]
        public async Task DeleteAsync_DeleteBlockWithGivenId()
        {
            var pageParentId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new ParentPageInput()
                    {
                        PageId = pageParentId
                    }
                ).Build()
            );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<IBlock>()
                    {
                        new DividerBlock
                        {
                            Divider = new DividerBlock.Data()
                        },
                        new TableOfContentsBlock
                        {
                            TableOfContents = new TableOfContentsBlock.Data()
                        },
                    }
                }
            );

            blocks.Results.Should().HaveCount(2);

            // cleanup
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Theory]
        [MemberData(nameof(BlockData))]
        public async Task UpdateAsync_UpdatesGivenBlock(IBlock block, IUpdateBlock updateBlock, Action<IBlock> assert)
        {
            var pageParentId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new ParentPageInput
                    {
                        PageId = pageParentId
                    }
                ).Build()
            );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<IBlock>()
                    {
                        block
                    }
                }
            );

            var blockId = blocks.Results.First().Id;
            await _client.Blocks.UpdateAsync(blockId, updateBlock);

            blocks = await _client.Blocks.RetrieveChildrenAsync(page.Id);
            blocks.Results.Should().HaveCount(1);

            var updatedBlock = blocks.Results.First();

            assert.Invoke(updatedBlock);

            // cleanup
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        private static IEnumerable<object[]> BlockData()
        {
            return new List<object[]>
            {
                new object[] {
                    new BookmarkBlock
                    {
                        Bookmark = new BookmarkBlock.Info
                        {
                            Url = "https://developers.notion.com/reference/rich-text",
                            Caption = new List<RichTextBase>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Notion API"
                                    }
                                }
                            }
                        }
                    },
                    new BookmarkUpdateBlock {
                        Bookmark = new BookmarkUpdateBlock.Data
                        {
                            Url = "https://github.com/notion-dotnet/notion-sdk-net",
                            Caption = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Github"
                                    }
                                }
                            }
                        }
                    },
                    new Action<IBlock>((block) => {
                        var updatedBlock = (BookmarkBlock)block;
                        Assert.Equal("https://github.com/notion-dotnet/notion-sdk-net", updatedBlock.Bookmark.Url);
                        Assert.Equal("Github", updatedBlock.Bookmark.Caption.OfType<RichTextText>().First().Text.Content);
                    })
                },
                new object[] {
                    new EquationBlock
                    {
                        Equation = new EquationBlock.Info
                        {
                            Expression = "e=mc^3"
                        }
                    },
                    new EquationUpdateBlock {
                        Equation = new EquationUpdateBlock.Data
                        {
                            Expression = "e=mc^2"
                        }
                    },
                    new Action<IBlock>((block) => {
                        var updatedBlock = (EquationBlock)block;
                        Assert.Equal("e=mc^2", updatedBlock.Equation.Expression);
                    })
                },
                new object[] {
                    new DividerBlock {
                        Divider = new DividerBlock.Data()
                    },
                    new DividerUpdateBlock(),
                    new Action<IBlock>((block) => {
                        Assert.NotNull(block);
                        Assert.IsType<DividerBlock>(block);
                    })
                },
                new object[] {
                    new AudioBlock {
                        Audio = new ExternalFile {
                            External = new ExternalFile.Info {
                                Url = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3"
                            }
                        }
                    },
                    new AudioUpdateBlock {
                        Audio = new ExternalFileInput {
                            External = new ExternalFileInput.Data {
                                Url = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-3.mp3"
                            }
                        }
                    },
                    new Action<IBlock>((block) => {
                        block.Should().NotBeNull();

                        block.Should().BeOfType<AudioBlock>().Subject
                            .Audio.Should().BeOfType<ExternalFile>().Subject
                            .External.Url.Should().Be("https://www.soundhelix.com/examples/mp3/SoundHelix-Song-3.mp3");
                    })
                },
                new object[]
                {
                    new TableOfContentsBlock {
                        TableOfContents = new TableOfContentsBlock.Data()
                    },
                    new TableOfContentsUpdateBlock(),
                    new Action<IBlock>((block) =>
                    {
                        Assert.NotNull(block);
                        Assert.IsType<TableOfContentsBlock>(block);
                    })
                },
                new object[]
                {
                    new CalloutBlock
                    {
                        Callout = new CalloutBlock.Info
                        {
                            Text = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Test"
                                    }
                                }
                            }
                        }
                    },
                    new CalloutUpdateBlock()
                    {
                        Callout = new CalloutUpdateBlock.Info
                        {
                            Text = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Test 2"
                                    }
                                }
                            }
                        }
                    },
                    new Action<IBlock>((block) =>
                    {
                        Assert.NotNull(block);
                        var calloutBlock = Assert.IsType<CalloutBlock>(block);

                        Assert.Equal("Test 2", calloutBlock.Callout.Text.OfType<RichTextText>().First().Text.Content);
                    })
                },
                new object[]
                {
                    new QuoteBlock
                    {
                        Quote = new QuoteBlock.Info
                        {
                            Text = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Test"
                                    }
                                }
                            }
                        }
                    },
                    new QuoteUpdateBlock()
                    {
                        Quote = new QuoteUpdateBlock.Info
                        {
                            Text = new List<RichTextBaseInput>
                            {
                                new RichTextTextInput
                                {
                                    Text = new Text
                                    {
                                        Content = "Test 2"
                                    }
                                }
                            }
                        }
                    },
                    new Action<IBlock>((block) =>
                    {
                        Assert.NotNull(block);
                        var quoteBlock = Assert.IsType<QuoteBlock>(block);

                        Assert.Equal("Test 2", quoteBlock.Quote.Text.OfType<RichTextText>().First().Text.Content);
                    })
                }
            };
        }
    }
}
