using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class CommentsClientTests : IDisposable
{
    private readonly INotionClient _client;
    private readonly Page _page;
    private readonly string _pageParentId;

    public CommentsClientTests()
    {
        var options = new ClientOptions {AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN")};

        _client = NotionClientFactory.Create(options);

        _pageParentId = Environment.GetEnvironmentVariable("NOTION_PAGE_PARENT_ID") ??
                        throw new ArgumentNullException("Page parent id is required.");

        _page = _client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new ParentPageInput {PageId = _pageParentId}
            ).Build()
        ).Result;
    }

    public void Dispose()
    {
        _client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters {Archived = true}).Wait();
    }

    [Fact]
    public async Task ShouldCreatePageComment()
    {
        // Arrange
        var parameters = CreateCommentParameters.CreatePageComment(
            new ParentPageInput {PageId = _page.Id},
            new List<RichTextBaseInput> {new RichTextTextInput {Text = new Text {Content = "This is a comment"}}}
        );

        // Act
        var response = await _client.Comments.Create(parameters);

        // Arrange

        Assert.NotNull(response.Parent);
        Assert.NotNull(response.Id);
        Assert.NotNull(response.DiscussionId);

        Assert.NotNull(response.RichText);
        Assert.Single(response.RichText);
        var richText = Assert.IsType<RichTextText>(response.RichText.First());
        Assert.Equal("This is a comment", richText.Text.Content);

        var pageParent = Assert.IsType<PageParent>(response.Parent);
        Assert.Equal(_page.Id, pageParent.PageId);
    }

    [Fact]
    public async Task ShouldCreateADiscussionComment()
    {
        // Arrange
        var comment = await _client.Comments.Create(
            CreateCommentParameters.CreatePageComment(
                new ParentPageInput {PageId = _page.Id},
                new List<RichTextBaseInput> {new RichTextTextInput {Text = new Text {Content = "This is a comment"}}}
            )
        );

        // Act
        var response = await _client.Comments.Create(
            CreateCommentParameters.CreateDiscussionComment(
                comment.DiscussionId,
                new List<RichTextBaseInput>
                {
                    new RichTextTextInput {Text = new Text {Content = "This is a sub comment"}},
                }
            )
        );

        // Arrange
        Assert.Null(response.Parent);
        Assert.NotNull(response.Id);
        Assert.Equal(comment.DiscussionId, response.DiscussionId);

        Assert.NotNull(response.RichText);
        Assert.Single(response.RichText);
        var richText = Assert.IsType<RichTextText>(response.RichText.First());
        Assert.Equal("This is a sub comment", richText.Text.Content);

        var pageParent = Assert.IsType<PageParent>(response.Parent);
        Assert.Equal(_page.Id, pageParent.PageId);
    }
}
