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
            INotionClient _client = new NotionClient(options);

            var pageId = "3c357473a28149a488c010d2b245a589";
            var blocks = await _client.Blocks.AppendChildrenAsync(
                pageId,
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

            blocks.Results.Should().HaveCount(1);

            // cleanup
            var tasks = blocks.Results.Select(x => _client.Blocks.DeleteAsync(x.Id));
            await Task.WhenAll(tasks);
        }

        [Fact]
        public async Task UpdateBlobkAsync_UpdatesGivenBlock()
        {
            var options = new ClientOptions
            {
                AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")
            };
            INotionClient _client = new NotionClient(options);

            var pageId = "3c357473a28149a488c010d2b245a589";
            var blocks = await _client.Blocks.AppendChildrenAsync(
                pageId,
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
            var tasks = blocks.Results.Select(x => _client.Blocks.DeleteAsync(x.Id));
            await Task.WhenAll(tasks);
        }
    }
}
