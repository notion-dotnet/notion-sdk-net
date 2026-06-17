using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "page.content_updated" webhook event.
    /// </summary>
    public class PageContentUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageContentUpdated;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageContentUpdatedData Data { get; set; }

        public class PageContentUpdatedData
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
    /// Payload for the "page.created" webhook event.
    /// </summary>
    public class PageCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageCreated;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "page.deleted" webhook event.
    /// </summary>
    public class PageDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageDeleted;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "page.locked" webhook event.
    /// </summary>
    public class PageLockedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageLocked;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "page.moved" webhook event.
    /// </summary>
    public class PageMovedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageMoved;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "page.properties_updated" webhook event.
    /// </summary>
    public class PagePropertiesUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PagePropertiesUpdated;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PagePropertiesUpdatedData Data { get; set; }

        public class PagePropertiesUpdatedData
        {
            /// <summary>
            /// The parent of the page whose properties were updated.
            /// </summary>
            [JsonProperty("parent")]
            public WebhookParentBlock Parent { get; set; }

            /// <summary>
            /// The IDs of the properties that were updated.
            /// </summary>
            [JsonProperty("updated_properties")]
            public List<string> UpdatedProperties { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "page.transcription_block.transcript_deleted" webhook event.
    /// </summary>
    public class PageTranscriptionBlockTranscriptDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageTranscriptionBlockTranscriptDeleted;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageTranscriptDeletedData Data { get; set; }

        public class PageTranscriptDeletedData
        {
            /// <summary>
            /// The block that contained the deleted transcript.
            /// </summary>
            [JsonProperty("target")]
            public WebhookExternalBlock Target { get; set; }

            /// <summary>
            /// The ID of the deleted transcript, or <c>null</c> if not available.
            /// </summary>
            [JsonProperty("transcript_id")]
            public string TranscriptId { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "page.undeleted" webhook event.
    /// </summary>
    public class PageUndeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageUndeleted;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "page.unlocked" webhook event.
    /// </summary>
    public class PageUnlockedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.PageUnlocked;

        /// <summary>
        /// The page that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookPageEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public PageParentData Data { get; set; }
    }

    /// <summary>
    /// Shared data class for page events that only carry a parent.
    /// </summary>
    public class PageParentData
    {
        /// <summary>
        /// The parent of the entity that triggered the event.
        /// </summary>
        [JsonProperty("parent")]
        public WebhookParentBlock Parent { get; set; }
    }
}
