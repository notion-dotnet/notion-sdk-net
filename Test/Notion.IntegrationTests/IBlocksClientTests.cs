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
        [Fact]
        public async Task AppendChildrenAsync_AppendsBlocksGivenBlocks()
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };
            INotionClient _client = NotionClientFactory.Create(options);

            var pageId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new ParentPageInput()
                    {
                        PageId = pageId
                    }
                ).Build()
            );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<Block>()
                    {
                        new BreadcrumbBlock
                        {
                            Breadcrumb = new BreadcrumbBlock.Data()
                        },
                        new DividerBlock
                        {
                            Divider = new DividerBlock.Data()
                        }
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

        [Fact]
        public async Task UpdateBlockAsync_UpdatesGivenBlock()
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };
            INotionClient _client = NotionClientFactory.Create(options);

            var pageId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                            PagesCreateParametersBuilder.Create(
                                new ParentPageInput()
                                {
                                    PageId = pageId
                                }
                            ).Build()
                        );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<Block>()
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

            blocks = await _client.Blocks.RetrieveChildrenAsync(pageId);
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
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };
            INotionClient _client = NotionClientFactory.Create(options);

            var pageId = "3c357473a28149a488c010d2b245a589";

            var page = await _client.Pages.CreateAsync(
                PagesCreateParametersBuilder.Create(
                    new ParentPageInput()
                    {
                        PageId = pageId
                    }
                ).Build()
            );

            var blocks = await _client.Blocks.AppendChildrenAsync(
                page.Id,
                new BlocksAppendChildrenParameters
                {
                    Children = new List<Block>()
                    {
                        new DividerBlock
                        {
                            Divider = new DividerBlock.Data()
                        }
                    }
                }
            );

            blocks.Results.Should().HaveCount(1);

            // cleanup
            await _client.Pages.UpdateAsync(page.Id, new PagesUpdateParameters
            {
                Archived = true
            });
        }

        [Theory]
        [MemberData(nameof(BlockData))]
        public async Task UpdateAsync_UpdatesGivenBlock(Block block, IUpdateBlock updateBlock, Action<Block> assert)
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };
            INotionClient _client = NotionClientFactory.Create(options);

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
                    Children = new List<Block>()
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
                    new Action<Block>((block) => {
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
                    new Action<Block>((block) => {
                        var updatedBlock = (EquationBlock)block;
                        Assert.Equal("e=mc^2", updatedBlock.Equation.Expression);
                    })
                },
                new object[] {
                    new DividerBlock {
                        Divider = new DividerBlock.Data()
                    },
                    new DividerUpdateBlock(),
                    new Action<Block>((block) => {
                        Assert.NotNull(block);
                        Assert.IsType<DividerBlock>(block);
                    })
                }
            };
        }
    }
}
