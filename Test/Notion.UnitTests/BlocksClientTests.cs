using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

public class BlocksClientTests : ApiTestBase
{
    private readonly IBlocksClient _client;

    public BlocksClientTests()
    {
        _client = new BlocksClient(new RestClient(ClientOptions));
    }

    [Fact]
    public async Task RetrieveBlockChildren()
    {
        // Arrange
        var blockId = "3c357473-a281-49a4-88c0-10d2b245a589";
        var path = ApiEndpoints.BlocksApiUrls.RetrieveChildren(blockId);
        var jsonData = await File.ReadAllTextAsync("data/blocks/RetrieveBlockChildrenResponse.json");

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        // Act
        var childrenResult = await _client.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest
        {
            BlockId = blockId
        });

        // Assert
        var children = childrenResult.Results;
        children.Should().HaveCount(9);
    }

    [Fact]
    public async Task AppendBlockChildren()
    {
        // Arrange
        var blockId = "7face6fd-3ef4-4b38-b1dc-c5044988eec0";
        var path = ApiEndpoints.BlocksApiUrls.AppendChildren(blockId);

        var jsonData = await File.ReadAllTextAsync("data/blocks/AppendBlockChildrenResponse.json");

        Server.Given(CreatePatchRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        var request = new BlockAppendChildrenRequest
        {
            BlockId = blockId,
            Children = new List<IBlockObjectRequest>
            {
                new HeadingTwoBlockRequest
                {
                    Heading_2 = new HeadingTwoBlockRequest.Info
                    {
                        RichText = new List<RichTextBase>
                        {
                            new RichTextText { Text = new Text { Content = "Lacinato kale" } }
                        }
                    }
                },
                new ParagraphBlockRequest
                {
                    Paragraph = new ParagraphBlockRequest.Info
                    {
                        RichText = new List<RichTextBase>
                        {
                            new RichTextText
                            {
                                Text = new Text
                                {
                                    Content
                                        = "Lacinato kale is a variety of kale with a long tradition in Italian cuisine, especially that of Tuscany. It is also known as Tuscan kale, Italian kale, dinosaur kale, kale, flat back kale, palm tree kale, or black Tuscan palm.",
                                    Link = new Link
                                    {
                                        Url
                                            = "https://en.wikipedia.org/wiki/Lacinato_kale"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        // Act
        var blocksResult = await _client.AppendChildrenAsync(request);

        // Assert
        var blocks = blocksResult.Results;

        blocks.Should().SatisfyRespectively(
            block =>
            {
                block.Type.Should().Be(BlockType.Heading_2);
                var headingBlock = (HeadingTwoBlock)block;
                var text = headingBlock.Heading_2.RichText.OfType<RichTextText>().First();
                text.Text.Content.Should().Be("Lacinato kale");
            },
            block =>
            {
                block.Type.Should().Be(BlockType.Paragraph);
                var paragraphBlock = (ParagraphBlock)block;
                var text = paragraphBlock.Paragraph.RichText.OfType<RichTextText>().Last();

                text.Text.Content.Should().Be(
                    "Lacinato kale is a variety of kale with a long tradition in Italian cuisine, especially that of Tuscany. It is also known as Tuscan kale, Italian kale, dinosaur kale, kale, flat back kale, palm tree kale, or black Tuscan palm.");

                text.Text.Link.Url.Should().Be("https://en.wikipedia.org/wiki/Lacinato_kale");
            }
        );
    }

    [Fact]
    public async Task RetrieveAsync()
    {
        var blockId = "9bc30ad4-9373-46a5-84ab-0a7845ee52e6";
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

        var todoBlock = (ToDoBlock)block;
        todoBlock.ToDo.RichText.Should().ContainSingle();
        todoBlock.ToDo.RichText.First().Should().BeAssignableTo<RichTextText>();
        ((RichTextText)todoBlock.ToDo.RichText.First()).Text.Content.Should().Be("Lacinato kale");
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var blockId = "9bc30ad4-9373-46a5-84ab-0a7845ee52e6";
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
                RichText = new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "Lacinato kale" } }
                },
                IsChecked = true
            }
        };

        var block = await _client.UpdateAsync(blockId, updateBlock);

        block.Id.Should().Be(blockId);
        block.HasChildren.Should().BeFalse();
        block.InTrash.Should().BeFalse();
        block.Type.Should().Be(BlockType.ToDo);

        var todoBlock = (ToDoBlock)block;
        todoBlock.ToDo.RichText.Should().ContainSingle();
        todoBlock.ToDo.RichText.First().Should().BeAssignableTo<RichTextText>();
        ((RichTextText)todoBlock.ToDo.RichText.First()).Text.Content.Should().Be("Lacinato kale");
    }
}
