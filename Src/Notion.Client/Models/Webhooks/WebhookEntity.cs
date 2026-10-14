using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a comment entity in a webhook event.
    /// </summary>
    public class WebhookCommentEntity
    {
        /// <summary>
        /// Always "comment".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the comment that triggered the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    /// <summary>
    /// Represents a page entity in a webhook event.
    /// </summary>
    public class WebhookPageEntity
    {
        /// <summary>
        /// Always "page".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the page that triggered the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    /// <summary>
    /// Represents a database or data source entity in a webhook event.
    /// </summary>
    public class WebhookDatabaseEventEntity
    {
        /// <summary>
        /// The ID of the database or data source that triggered the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of entity. For linked databases, this is "block". Can be "block", "database", or "data_source".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents a file upload entity in a webhook event.
    /// </summary>
    public class WebhookFileUploadEntity
    {
        /// <summary>
        /// Always "file_upload".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the file upload that triggered the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    /// <summary>
    /// Represents a view entity in a webhook event.
    /// </summary>
    public class WebhookViewEntity
    {
        /// <summary>
        /// The ID of the view that triggered the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Always "view".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
