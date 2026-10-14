using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreateCommentRequest : ICreateDiscussionCommentBodyParameters, ICreatePageCommentBodyParameters
    {
        public string DiscussionId { get; set; }

        public IEnumerable<RichTextBaseInput> RichText { get; set; }

        public ParentPageInput Parent { get; set; }

        /// <summary>
        /// The content as a Markdown string, as an alternative to <see cref="RichText" />.
        /// Supports inline formatting only (bold, italic, strikethrough, code, links), inline equations and mentions.
        /// </summary>
        [JsonProperty("markdown")]
        public string Markdown { get; set; }

        /// <summary>
        /// Files to attach (max 3). Each must be a file upload with status <c>uploaded</c>.
        /// </summary>
        [JsonProperty("attachments")]
        public IEnumerable<CommentAttachmentRequest> Attachments { get; set; }

        /// <summary>
        /// Display name for the comment.
        /// </summary>
        [JsonProperty("display_name")]
        public CommentDisplayName DisplayName { get; set; }

        public static CreateCommentRequest CreatePageComment(
            ParentPageInput parent,
            IEnumerable<RichTextBaseInput> richText)
        {
            return new CreateCommentRequest
            {
                Parent = parent,
                RichText = richText
            };
        }

        public static CreateCommentRequest CreatePageMarkdownComment(ParentPageInput parent, string markdown)
        {
            return new CreateCommentRequest
            {
                Parent = parent,
                Markdown = markdown
            };
        }

        public static CreateCommentRequest CreateDiscussionMarkdownComment(string discussionId, string markdown)
        {
            return new CreateCommentRequest
            {
                DiscussionId = discussionId,
                Markdown = markdown
            };
        }

        public static CreateCommentRequest CreateDiscussionComment(
            string discussionId,
            IEnumerable<RichTextBaseInput> richText)
        {
            return new CreateCommentRequest
            {
                DiscussionId = discussionId,
                RichText = richText
            };
        }
    }
}
