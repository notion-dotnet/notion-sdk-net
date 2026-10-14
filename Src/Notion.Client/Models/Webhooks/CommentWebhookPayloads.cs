using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "comment.created" webhook event.
    /// </summary>
    public class CommentCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.CommentCreated;

        /// <summary>
        /// The comment that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookCommentEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public CommentEventData Data { get; set; }

        /// <summary>
        /// Event data shared by all comment webhook payload types.
        /// </summary>
        public class CommentEventData
        {
            /// <summary>
            /// The parent of the comment (the page or block the comment is attached to).
            /// </summary>
            [JsonProperty("parent")]
            public WebhookExternalBlock Parent { get; set; }

            /// <summary>
            /// The ID of the page containing the comment.
            /// </summary>
            [JsonProperty("page_id")]
            public string PageId { get; set; }
        }
    }

    /// <summary>
    /// Payload for the "comment.updated" webhook event.
    /// </summary>
    public class CommentUpdatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.CommentUpdated;

        /// <summary>
        /// The comment that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookCommentEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public CommentCreatedWebhookPayload.CommentEventData Data { get; set; }
    }

    /// <summary>
    /// Payload for the "comment.deleted" webhook event.
    /// </summary>
    public class CommentDeletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.CommentDeleted;

        /// <summary>
        /// The comment that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookCommentEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public CommentCreatedWebhookPayload.CommentEventData Data { get; set; }
    }
}
