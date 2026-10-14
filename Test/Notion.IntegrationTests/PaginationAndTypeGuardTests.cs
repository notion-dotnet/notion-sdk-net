using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class PaginationAndTypeGuardTests : IntegrationTestBase, IAsyncLifetime
{
    private const int ParagraphCount = 25;
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());

        await Client.Blocks.AppendChildrenAsync(new BlockAppendChildrenRequest
        {
            BlockId = _page.Id,
            Children = Enumerable.Range(1, ParagraphCount)
                .Select(i => (IBlockObjectRequest)new ParagraphBlockRequest
                {
                    Paragraph = new ParagraphBlockRequest.Info
                    {
                        RichText = new List<RichTextBaseInput>
                        {
                            new RichTextTextInput { Text = new Text { Content = $"Paragraph {i}" } }
                        }
                    }
                })
                .ToList()
        });
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    private async Task<PaginatedList<IBlock>> ListChildren(string? cursor)
    {
        return await Client.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest
        {
            BlockId = _page.Id, StartCursor = cursor, PageSize = 10
        });
    }

    [Fact]
    public async Task IteratePaginatedAsync_YieldsEveryItemAcrossPages()
    {
        var blocks = new List<IBlock>();

        await foreach (var block in NotionPaginationHelper.IteratePaginatedAsync<IBlock>(ListChildren!))
        {
            blocks.Add(block);
        }

        blocks.Should().HaveCount(ParagraphCount);
        blocks.Select(b => b.Id).Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task CollectPaginatedAsync_ReturnsTheSameItemsAsIterating()
    {
        var collected = await NotionPaginationHelper.CollectPaginatedAsync<IBlock>(ListChildren!);

        collected.Should().HaveCount(ParagraphCount);
        collected.Cast<ParagraphBlock>().First().Paragraph.RichText.OfType<RichTextText>().First().Text.Content
            .Should().Be("Paragraph 1");
    }

    [Fact]
    public async Task IsFull_Guards_Accept_Real_Responses()
    {
        var page = await Client.Pages.RetrieveAsync(_page.Id);
        var children = await Client.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest { BlockId = _page.Id });
        var me = await Client.Users.MeAsync();

        NotionTypeGuards.IsFullPage(page).Should().BeTrue();
        NotionTypeGuards.IsFullPageOrDataSource(page).Should().BeTrue();
        children.Results.Should().OnlyContain(b => NotionTypeGuards.IsFullBlock(b));
        NotionTypeGuards.IsFullUser(me).Should().BeTrue();
    }

    [Fact]
    public async Task IsFull_Guards_Accept_Database_DataSource_And_Comment()
    {
        var database = await Client.Databases.RetrieveAsync(ParentDatabaseId);
        var dataSource = await Client.DataSources.RetrieveAsync(
            new RetrieveDataSourceRequest { DataSourceId = database.DataSources.First().DataSourceId });
        var comment = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "guard" } } }));

        NotionTypeGuards.IsFullDatabase(database).Should().BeTrue();
        NotionTypeGuards.IsFullDataSource(dataSource).Should().BeTrue();
        NotionTypeGuards.IsFullComment(comment).Should().BeTrue();
    }
}
