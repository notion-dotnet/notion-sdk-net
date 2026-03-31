using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkCommentToPage : ILinkToPage
    {
        [JsonProperty("type")]
        public string Type => "comment_id";

        [JsonProperty("comment_id")]
        public string CommentId { get; set; }
    }
}
