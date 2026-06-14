using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Base class for all Update Page Markdown operations.
    /// Use one of the concrete subtypes: <see cref="InsertContentMarkdownBody"/>,
    /// <see cref="ReplaceContentRangeMarkdownBody"/>, <see cref="UpdateContentMarkdownBody"/>,
    /// or <see cref="ReplaceContentMarkdownBody"/>.
    /// </summary>
    public abstract class UpdatePageMarkdownBody
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }
}
