using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreateCommentsBodyParameters
    {
        [JsonProperty("rich_text")]
        public IEnumerable<RichTextBaseInput> RichText { get; set; }
    }

    public interface ICreateDiscussionCommentBodyParameters : ICreateCommentsBodyParameters
    {
        [JsonProperty("discussion_id")]
        public string DiscussionId { get; set; }
    }

    public interface ICreatePageCommentBodyParameters : ICreateCommentsBodyParameters
    {
        [JsonProperty("parent")]
        public ParentPageInput Parent { get; set; }
    }

    public class CreateCommentParameters : ICreateDiscussionCommentBodyParameters, ICreatePageCommentBodyParameters
    {
        public string DiscussionId { get; set; }

        public IEnumerable<RichTextBaseInput> RichText { get; set; }

        public ParentPageInput Parent { get; set; }

        public static CreateCommentParameters CreatePageComment(
            ParentPageInput parent,
            IEnumerable<RichTextBaseInput> richText)
        {
            return new CreateCommentParameters
            {
                Parent = parent,
                RichText = richText
            };
        }

        public static CreateCommentParameters CreateDiscussionComment(
            string discussionId,
            IEnumerable<RichTextBaseInput> richText)
        {
            return new CreateCommentParameters
            {
                DiscussionId = discussionId,
                RichText = richText
            };
        }
    }
}
