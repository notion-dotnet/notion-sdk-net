using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "view.created" webhook event.
    /// </summary>
    public class ViewCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.ViewCreated;

        /// <summary>
        /// The view that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookViewEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public ViewCreatedData Data { get; set; }

        public class ViewCreatedData
        {
            /// <summary>
            /// The parent of the created view.
            /// </summary>
            [JsonProperty("parent")]
            public WebhookParentBlock Parent { get; set; }

            /// <summary>
            /// The type of the created view (e.g. "table", "board", "list", "calendar", "gallery", "timeline").
            /// </summary>
            [JsonProperty("view_type")]
            public string ViewType { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "view.deleted" webhook event.
    /// </summary>
    public class ViewDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.ViewDeleted;

        /// <summary>
        /// The view that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookViewEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public ViewParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "view.updated" webhook event.
    /// </summary>
    public class ViewUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.ViewUpdated;

        /// <summary>
        /// The view that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookViewEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public ViewUpdatedData Data { get; set; }

        public class ViewUpdatedData
        {
            /// <summary>
            /// The parent of the updated view.
            /// </summary>
            [JsonProperty("parent")]
            public WebhookParentBlock Parent { get; set; }

            /// <summary>
            /// The fields of the view that were updated.
            /// </summary>
            [JsonProperty("updated_fields")]
            public List<string> UpdatedFields { get; set; }
        }
    }

    /// <summary>
    /// Shared data class for view events that only carry a parent.
    /// </summary>
    public class ViewParentData
    {
        /// <summary>
        /// The parent of the entity that triggered the event.
        /// </summary>
        [JsonProperty("parent")]
        public WebhookParentBlock Parent { get; set; }
    }
}
