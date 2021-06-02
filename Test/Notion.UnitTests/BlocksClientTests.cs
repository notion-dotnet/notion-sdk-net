using System.Collections.Generic;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests
{
    public class BlocksClientTests
    {
        private readonly IBlocksClient _client;

        public BlocksClientTests()
        {
            var options = new ClientOptions()
            {
                AuthToken = "<Token>"
            };

            _client = new BlocksClient(new RestClient(options));
        }

        [Fact(Skip = "Dev only")]
        public async Task RetrieveBlockChildren()
        {
            string blockId = "3c357473-a281-49a4-88c0-10d2b245a589";

            var children = await _client.RetrieveChildrenAsync(blockId, new BlocksRetrieveChildrenParameters());

            Assert.NotNull(children);
        }

        [Fact(Skip = "Dev only")]
        public async Task AppendBlockChildren()
        {
            string blockId = "3c357473-a281-49a4-88c0-10d2b245a589";

            var parameters = new BlocksAppendChildrenParameters()
            {
                Children = new List<Block>
                {
                    new HeadingTwoBlock()
                    {
                        Heading_2 = new HeadingTwoBlock.Info
                        {
                            Text = new List<RichTextBase>
                            {
                                new RichTextText
                                {
                                    Text = new Text
                                    {
                                        Content = "Lacinato kale"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var block = await _client.AppendChildrenAsync(blockId, parameters);

            Assert.NotNull(block);
        }
    }
}