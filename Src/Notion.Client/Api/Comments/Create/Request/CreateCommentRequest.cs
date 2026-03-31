using System.Collections.Generic;

namespace Notion.Client
{
    public class CreateCommentRequest : ICreateDiscussionCommentBodyParameters, ICreatePageCommentBodyParameters
    {
        public string DiscussionId { get; set; }

        public IEnumerable<RichTextBaseInput> RichText { get; set; }

        public ParentPageInput Parent { get; set; }

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
