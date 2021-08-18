using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests
{
    public class BlocksClientTests : ApiTestBase
    {
        private readonly IBlocksClient _client;

        public BlocksClientTests()
        {
            _client = new BlocksClient(new RestClient(ClientOptions));
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

        [Fact]
        public async Task RetrieveAsync()
        {
            string blockId = "9bc30ad4-9373-46a5-84ab-0a7845ee52e6";
            var path = ApiEndpoints.BlocksApiUrls.Retrieve(blockId);
            var jsonData = await File.ReadAllTextAsync("data/blocks/RetrieveBlockResponse.json");

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var block = await _client.RetrieveAsync(blockId);

            block.Id.Should().Be(blockId);
            block.HasChildren.Should().BeFalse();
            block.Type.Should().Be(BlockType.ToDo);

            var todoBlock = ((ToDoBlock)block);
            todoBlock.ToDo.Text.Should().ContainSingle();
            todoBlock.ToDo.Text.First().Should().BeAssignableTo<RichTextText>();
            ((RichTextText)todoBlock.ToDo.Text.First()).Text.Content.Should().Be("Lacinato kale");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            string blockId = "9bc30ad4-9373-46a5-84ab-0a7845ee52e6";
            var path = ApiEndpoints.BlocksApiUrls.Update(blockId);
            var jsonData = await File.ReadAllTextAsync("data/blocks/UpdateBlockResponse.json");

            Server.Given(CreatePatchRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            var updateBlock = new ToDoUpdateBlock
            {
                ToDo = new ToDoUpdateBlock.Info
                {
                    Text = new List<RichTextBaseInput>()
                    {
                        new RichTextTextInput
                        {
                            Text = new Text
                            {
                                Content = "Lacinato kale"
                            },
                        }
                    },
                    IsChecked = true
                }
            };

            var block = await _client.UpdateAsync(blockId, updateBlock);

            block.Id.Should().Be(blockId);
            block.HasChildren.Should().BeFalse();
            block.Type.Should().Be(BlockType.ToDo);

            var todoBlock = ((ToDoBlock)block);
            todoBlock.ToDo.Text.Should().ContainSingle();
            todoBlock.ToDo.Text.First().Should().BeAssignableTo<RichTextText>();
            ((RichTextText)todoBlock.ToDo.Text.First()).Text.Content.Should().Be("Lacinato kale");
        }
    }
}
