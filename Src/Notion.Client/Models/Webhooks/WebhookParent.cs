using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a parent block in a webhook event, including workspace-level parents.
    /// </summary>
    public class WebhookParentBlock
    {
        /// <summary>
        /// The ID of the parent.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the parent. One of "space", "block", "page", "database", "team", or "agent".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The data source ID of the parent, if applicable.
        /// </summary>
        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }
    }

    /// <summary>
    /// Represents an external block reference (e.g., the parent of a comment).
    /// </summary>
    public class WebhookExternalBlock
    {
        /// <summary>
        /// The ID of the parent.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the parent. One of "page", "database", or "block".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
