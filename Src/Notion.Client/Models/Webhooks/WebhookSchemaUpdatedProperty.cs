using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a database property that was created, updated, or deleted in a schema update event.
    /// </summary>
    public class WebhookSchemaUpdatedProperty
    {
        /// <summary>
        /// The ID of the database property that changed.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the database property, or <c>null</c> if deleted.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The action taken on the property. One of "created", "updated", or "deleted".
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
