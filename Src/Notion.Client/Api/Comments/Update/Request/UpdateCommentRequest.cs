using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UpdateCommentRequest
    {
        public string CommentId { get; set; }

        [JsonProperty("rich_text")]
        public IEnumerable<RichTextBase> RichText { get; set; }
    }
}
