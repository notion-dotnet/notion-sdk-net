using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class CommentsClientTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(
                new PageParentRequest { PageId = ParentPageId }
            ).Build()
        );
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task ShouldCreatePageComment()
    {
        // Arrange
        var parameters = CreateCommentRequest.CreatePageComment(
            new ParentPageInput { PageId = _page.Id },
            new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "This is a comment" } } }
        );

        // Act
        var response = await Client.Comments.CreateAsync(parameters);

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
        var comment = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "This is a comment" } }
                }
            )
        );

        // Act
        var response = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreateDiscussionComment(
                comment.DiscussionId,
                new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "This is a sub comment" } }
                }
            )
        );

        // Arrange
        Assert.NotNull(response.Parent);
        Assert.NotNull(response.Id);
        Assert.Equal(comment.DiscussionId, response.DiscussionId);

        Assert.NotNull(response.RichText);
        Assert.Single(response.RichText);
        var richText = Assert.IsType<RichTextText>(response.RichText.First());
        Assert.Equal("This is a sub comment", richText.Text.Content);

        var pageParent = Assert.IsType<PageParent>(response.Parent);
        Assert.Equal(_page.Id, pageParent.PageId);
    }

    [Fact]
    public async Task ShouldRetrieveSingleComment()
    {
        // Arrange — create a comment first
        var created = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Comment to retrieve" } } }
            )
        );

        // Act
        var retrieved = await Client.Comments.RetrieveSingleAsync(
            new RetrieveSingleCommentRequest { CommentId = created.Id }
        );

        // Assert
        Assert.NotNull(retrieved);
        Assert.Equal(created.Id, retrieved.Id);
        Assert.Equal(created.DiscussionId, retrieved.DiscussionId);
        var richText = Assert.IsType<RichTextText>(retrieved.RichText.First());
        Assert.Equal("Comment to retrieve", richText.Text.Content);
    }

    [Fact]
    public async Task ShouldUpdateComment()
    {
        // Arrange — create a comment first
        var created = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Original text" } } }
            )
        );

        // Act
        var updated = await Client.Comments.UpdateAsync(new UpdateCommentRequest
        {
            CommentId = created.Id,
            RichText = new List<RichTextBase>
            {
                new RichTextText { Text = new Text { Content = "Updated text" } }
            }
        });

        // Assert
        Assert.NotNull(updated);
        Assert.Equal(created.Id, updated.Id);
        var richText = Assert.IsType<RichTextText>(updated.RichText.First());
        Assert.Equal("Updated text", richText.Text.Content);
    }

    [Fact]
    public async Task ShouldCreatePageCommentFromMarkdown()
    {
        var response = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageMarkdownComment(
                new ParentPageInput { PageId = _page.Id },
                "Some **bold** text"
            )
        );

        Assert.NotNull(response);
        Assert.Contains(
            response.RichText.OfType<RichTextText>(),
            t => t.Text.Content.Contains("bold") && t.Annotations.IsBold);
    }

    [Fact]
    public async Task ShouldUpdateCommentFromMarkdown()
    {
        var created = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Original" } } }
            )
        );

        var updated = await Client.Comments.UpdateAsync(
            new UpdateCommentRequest { CommentId = created.Id, Markdown = "Edited with *markdown*" }
        );

        Assert.Equal(created.Id, updated.Id);
        Assert.Contains(
            updated.RichText.OfType<RichTextText>(),
            t => t.Text.Content.Contains("markdown") && t.Annotations.IsItalic);
    }

    [Fact]
    public async Task ShouldCreateCommentWithCustomDisplayName()
    {
        var request = CreateCommentRequest.CreatePageComment(
            new ParentPageInput { PageId = _page.Id },
            new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Signed comment" } } }
        );
        request.DisplayName = CommentDisplayName.CustomName("Release Bot");

        var response = await Client.Comments.CreateAsync(request);

        Assert.NotNull(response.DisplayName);
        Assert.Equal("custom", response.DisplayName.Type);
        Assert.Equal("Release Bot", response.DisplayName.ResolvedName);
    }

    [Fact]
    public async Task ShouldCreateCommentWithAttachment()
    {
        var upload = await Client.FileUploads.CreateAsync(
            new CreateFileUploadRequest { Mode = FileUploadMode.SinglePart, FileName = "notion-logo.png" });

        using (var fileStream = System.IO.File.OpenRead("assets/notion-logo.png"))
        {
            await Client.FileUploads.SendAsync(
                SendFileUploadRequest.Create(
                    upload.Id,
                    new FileData
                    {
                        FileName = "notion-logo.png", Data = fileStream, ContentType = upload.ContentType
                    }));
        }

        var request = CreateCommentRequest.CreatePageComment(
            new ParentPageInput { PageId = _page.Id },
            new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "See attachment" } } }
        );
        request.Attachments = new[] { new CommentAttachmentRequest(upload.Id) };

        var response = await Client.Comments.CreateAsync(request);

        var attachment = Assert.Single(response.Attachments);
        Assert.Equal("image", attachment.Category);
        Assert.False(string.IsNullOrEmpty(attachment.File.Url));
    }

    [Fact]
    public async Task ShouldDeleteComment()
    {
        // Arrange — create a comment first
        var created = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput> { new RichTextTextInput { Text = new Text { Content = "Comment to delete" } } }
            )
        );

        // Act — delete should not throw
        await Client.Comments.DeleteAsync(created.Id);

        // Assert — retrieving the deleted comment should fail or return nothing
        var comments = await Client.Comments.RetrieveAsync(
            new RetrieveCommentsRequest { BlockId = _page.Id }
        );

        Assert.DoesNotContain(comments.Results, c => c.Id == created.Id);
    }
}
