using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a block that was updated in a webhook event.
    /// </summary>
    public class WebhookUpdatedBlock
    {
        /// <summary>
        /// The ID of the updated block.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the updated block. One of "page", "database", or "block".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
