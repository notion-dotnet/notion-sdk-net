using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Inserts new markdown content into the page at the specified position.
    /// </summary>
    public class InsertContentMarkdownBody : UpdatePageMarkdownBody
    {
        public override string Type => "insert_content";

        [JsonProperty("insert_content")]
        public InsertContentData InsertContent { get; set; }
    }

    public class InsertContentData
    {
        /// <summary>
        /// The enhanced markdown content to insert.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Ellipsis-format selection of existing content to insert after (e.g. "start text...end text").
        /// Omit to append at the end of the page. Cannot be combined with <see cref="Position"/>.
        /// </summary>
        [JsonProperty("after")]
        public string After { get; set; }

        /// <summary>
        /// Explicit position for the inserted content. Cannot be combined with <see cref="After"/>.
        /// </summary>
        [JsonProperty("position")]
        public MarkdownInsertPosition Position { get; set; }
    }

    /// <summary>
    /// Controls where inserted markdown content is placed within the page.
    /// </summary>
    public abstract class MarkdownInsertPosition
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }

    /// <summary>
    /// Inserts content at the start of the page.
    /// </summary>
    public class StartMarkdownInsertPosition : MarkdownInsertPosition
    {
        public override string Type => "start";
    }

    /// <summary>
    /// Inserts content at the end of the page.
    /// </summary>
    public class EndMarkdownInsertPosition : MarkdownInsertPosition
    {
        public override string Type => "end";
    }
}
