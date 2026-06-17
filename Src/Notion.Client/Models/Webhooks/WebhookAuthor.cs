using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a user or bot that performed a webhook-triggering action.
    /// </summary>
    public class WebhookAuthor
    {
        /// <summary>
        /// The ID of the user or bot.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the author. Either "person" or "bot".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
