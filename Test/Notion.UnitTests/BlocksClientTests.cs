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

        [Fact(Skip ="Dev only")]
        public async Task RetrieveBlockChildren()
        {
            string blockId = "3c357473-a281-49a4-88c0-10d2b245a589";
            
            var children = await _client.RetrieveChildrenAsync(blockId, new BlockRetrieveChildrenParameters());

            Assert.NotNull(children);
        }
    }
}