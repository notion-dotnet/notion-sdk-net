using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "data_source.content_updated" webhook event.
    /// </summary>
    public class DataSourceContentUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceContentUpdated;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceContentUpdatedData Data { get; set; }

        public class DataSourceContentUpdatedData
        {
            /// <summary>
            /// The parent of the entity whose content was updated.
            /// </summary>
            [JsonProperty("parent")]
            public WebhookParentBlock Parent { get; set; }

            /// <summary>
            /// The blocks that were updated in this event.
            /// </summary>
            [JsonProperty("updated_blocks")]
            public List<WebhookUpdatedBlock> UpdatedBlocks { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "data_source.created" webhook event.
    /// </summary>
    public class DataSourceCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceCreated;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "data_source.deleted" webhook event.
    /// </summary>
    public class DataSourceDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceDeleted;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "data_source.moved" webhook event.
    /// </summary>
    public class DataSourceMovedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceMoved;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "data_source.schema_updated" webhook event.
    /// </summary>
    public class DataSourceSchemaUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceSchemaUpdated;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceSchemaUpdatedData Data { get; set; }

        public class DataSourceSchemaUpdatedData
        {
            /// <summary>
            /// The parent of the data source whose schema was updated.
            /// </summary>
            [JsonProperty("parent")]
            public WebhookParentBlock Parent { get; set; }

            /// <summary>
            /// The database properties that were created, updated, or deleted.
            /// </summary>
            [JsonProperty("updated_properties")]
            public List<WebhookSchemaUpdatedProperty> UpdatedProperties { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "data_source.undeleted" webhook event.
    /// </summary>
    public class DataSourceUndeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DataSourceUndeleted;

        /// <summary>
        /// The data source that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DataSourceParentData Data { get; set; }
    }

    /// <summary>
    /// Shared data class for data source events that only carry a parent.
    /// </summary>
    public class DataSourceParentData
    {
        /// <summary>
        /// The parent of the entity that triggered the event.
        /// </summary>
        [JsonProperty("parent")]
        public WebhookParentBlock Parent { get; set; }
    }
}
