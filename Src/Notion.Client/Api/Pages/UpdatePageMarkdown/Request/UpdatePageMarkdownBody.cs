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

        /// <summary>
        /// Opt into receiving an async task when the work is accepted for background execution.
        /// Set by <see cref="IPagesClient.UpdateMarkdownWithAsyncTaskAsync" />; the plain method rejects it because its
        /// return type cannot represent an async task.
        /// </summary>
        [JsonProperty("allow_async")]
        public bool? AllowAsync { get; set; }
    }
}
