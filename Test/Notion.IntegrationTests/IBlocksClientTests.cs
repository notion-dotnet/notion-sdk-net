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
    }
}
