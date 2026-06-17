using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "database.content_updated" webhook event.
    /// </summary>
    public class DatabaseContentUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseContentUpdated;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseContentUpdatedData Data { get; set; }

        public class DatabaseContentUpdatedData
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
    /// Payload for the "database.created" webhook event.
    /// </summary>
    public class DatabaseCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseCreated;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "database.deleted" webhook event.
    /// </summary>
    public class DatabaseDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseDeleted;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "database.moved" webhook event.
    /// </summary>
    public class DatabaseMovedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseMoved;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "database.schema_updated" webhook event.
    /// </summary>
    public class DatabaseSchemaUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseSchemaUpdated;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseSchemaUpdatedData Data { get; set; }

        public class DatabaseSchemaUpdatedData
        {
            /// <summary>
            /// The parent of the database whose schema was updated.
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
    /// Payload for the "database.undeleted" webhook event.
    /// </summary>
    public class DatabaseUndeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.DatabaseUndeleted;

        /// <summary>
        /// The database that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookDatabaseEventEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public DatabaseParentData Data { get; set; }
    }

    /// <summary>
    /// Shared data class for database events that only carry a parent.
    /// </summary>
    public class DatabaseParentData
    {
        /// <summary>
        /// The parent of the entity that triggered the event.
        /// </summary>
        [JsonProperty("parent")]
        public WebhookParentBlock Parent { get; set; }
    }
}
