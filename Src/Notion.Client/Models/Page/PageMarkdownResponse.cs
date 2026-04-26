using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageMarkdownResponse : IObject
    {
        public string Id { get; set; }

        public ObjectType Object => ObjectType.PageMarkdown;

        /// <summary>
        /// The page content rendered as enhanced Markdown.
        /// </summary>
        [JsonProperty("markdown")]
        public string Markdown { get; set; }

        /// <summary>
        /// Whether the content was truncated due to exceeding the record count limit.
        /// </summary>
        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        /// <summary>
        /// Block IDs that could not be loaded (appeared as <unknown> tags in the markdown). 
        /// Pass these IDs back to this endpoint to fetch their content separately.
        /// </summary>
        [JsonProperty("unknown_block_ids")]
        public IEnumerable<string> UnknownBlockIds { get; set; }
    }
}