using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Base class for all Notion webhook event payloads.
    /// Discriminated on the "type" field; unknown types deserialize as <see cref="UnknownWebhookPayload"/>.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CommentCreatedWebhookPayload), WebhookEventType.CommentCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CommentUpdatedWebhookPayload), WebhookEventType.CommentUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CommentDeletedWebhookPayload), WebhookEventType.CommentDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceContentUpdatedWebhookPayload), WebhookEventType.DataSourceContentUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceCreatedWebhookPayload), WebhookEventType.DataSourceCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceDeletedWebhookPayload), WebhookEventType.DataSourceDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceMovedWebhookPayload), WebhookEventType.DataSourceMovedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceSchemaUpdatedWebhookPayload), WebhookEventType.DataSourceSchemaUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DataSourceUndeletedWebhookPayload), WebhookEventType.DataSourceUndeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseContentUpdatedWebhookPayload), WebhookEventType.DatabaseContentUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseCreatedWebhookPayload), WebhookEventType.DatabaseCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseDeletedWebhookPayload), WebhookEventType.DatabaseDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseMovedWebhookPayload), WebhookEventType.DatabaseMovedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseSchemaUpdatedWebhookPayload), WebhookEventType.DatabaseSchemaUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatabaseUndeletedWebhookPayload), WebhookEventType.DatabaseUndeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileUploadCompletedWebhookPayload), WebhookEventType.FileUploadCompletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileUploadCreatedWebhookPayload), WebhookEventType.FileUploadCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileUploadExpiredWebhookPayload), WebhookEventType.FileUploadExpiredValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileUploadUploadFailedWebhookPayload), WebhookEventType.FileUploadUploadFailedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageContentUpdatedWebhookPayload), WebhookEventType.PageContentUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageCreatedWebhookPayload), WebhookEventType.PageCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageDeletedWebhookPayload), WebhookEventType.PageDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageLockedWebhookPayload), WebhookEventType.PageLockedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageMovedWebhookPayload), WebhookEventType.PageMovedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PagePropertiesUpdatedWebhookPayload), WebhookEventType.PagePropertiesUpdatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageTranscriptionBlockTranscriptDeletedWebhookPayload), WebhookEventType.PageTranscriptionBlockTranscriptDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageUndeletedWebhookPayload), WebhookEventType.PageUndeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PageUnlockedWebhookPayload), WebhookEventType.PageUnlockedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ViewCreatedWebhookPayload), WebhookEventType.ViewCreatedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ViewDeletedWebhookPayload), WebhookEventType.ViewDeletedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ViewUpdatedWebhookPayload), WebhookEventType.ViewUpdatedValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(UnknownWebhookPayload))]
    public abstract class WebhookPayload
    {
        /// <summary>
        /// Unique identifier for this webhook event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// ISO 8601 timestamp of when the event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The ID of the workspace where the event originated.
        /// </summary>
        [JsonProperty("workspace_id")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// The name of the workspace where the event originated.
        /// </summary>
        [JsonProperty("workspace_name")]
        public string WorkspaceName { get; set; }

        /// <summary>
        /// The ID of the webhook subscription.
        /// </summary>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The ID of the integration the subscription is set up with.
        /// </summary>
        [JsonProperty("integration_id")]
        public string IntegrationId { get; set; }

        /// <summary>
        /// The users or bots that performed the action.
        /// </summary>
        [JsonProperty("authors")]
        public List<WebhookAuthor> Authors { get; set; }

        /// <summary>
        /// The delivery attempt number (1–8) of the current event delivery.
        /// </summary>
        [JsonProperty("attempt_number")]
        public int AttemptNumber { get; set; }

        /// <summary>
        /// The Notion API version used to render this webhook event's shape.
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// The users or bots who own the bot connection and have access to the webhook's entity.
        /// Only present for public integrations.
        /// </summary>
        [JsonProperty("accessible_by")]
        public List<WebhookAuthor> AccessibleBy { get; set; }

        /// <summary>
        /// The type of webhook event.
        /// </summary>
        [JsonProperty("type")]
        public virtual WebhookEventType Type { get; set; }
    }
}
