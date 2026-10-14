using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class MentionTypesTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

    [Fact]
    public async Task Comment_With_CustomEmoji_Mention_Is_Returned_As_CustomEmoji_Mention()
    {
        // The id of a custom emoji in your workspace (see Client.Emojis.ListAsync).
        var emojiId = GetEnvironmentVariableRequired("NOTION_CUSTOM_EMOJI_ID");

        var comment = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput>
                {
                    new RichTextMentionInput
                    {
                        Mention = new MentionInput
                        {
                            Type = "custom_emoji", CustomEmoji = new CustomEmojiRequest { Id = emojiId }
                        }
                    }
                }));

        var mention = comment.RichText.OfType<RichTextMention>().Should().ContainSingle().Subject.Mention;
        mention.Type.Should().Be("custom_emoji");
        mention.CustomEmoji.Id.Should().Be(emojiId);
        mention.CustomEmoji.Name.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Comment_With_Page_Mention_Still_Works()
    {
        var comment = await Client.Comments.CreateAsync(
            CreateCommentRequest.CreatePageComment(
                new ParentPageInput { PageId = _page.Id },
                new List<RichTextBaseInput>
                {
                    new RichTextMentionInput
                    {
                        Mention = new MentionInput { Type = "page", Page = new ObjectId { Id = ParentPageId } }
                    }
                }));

        var mention = comment.RichText.OfType<RichTextMention>().Should().ContainSingle().Subject.Mention;
        mention.Type.Should().Be("page");
        mention.Page.Id.Should().NotBeNullOrEmpty();
    }
}
