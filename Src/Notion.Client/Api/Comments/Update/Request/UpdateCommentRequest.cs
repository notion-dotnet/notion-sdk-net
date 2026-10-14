using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UpdateCommentRequest
    {
        [JsonIgnore]
        public string CommentId { get; set; }

        [JsonProperty("rich_text")]
        public IEnumerable<RichTextBase> RichText { get; set; }

        /// <summary>
        /// The new content as a Markdown string, as an alternative to <see cref="RichText" />.
        /// </summary>
        [JsonProperty("markdown")]
        public string Markdown { get; set; }
    }
}
