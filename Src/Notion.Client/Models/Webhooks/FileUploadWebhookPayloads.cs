using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Payload for the "file_upload.completed" webhook event.
    /// </summary>
    public class FileUploadCompletedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.FileUploadCompleted;

        /// <summary>
        /// The file upload that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookFileUploadEntity Entity { get; set; }
    }

    /// <summary>
    /// Payload for the "file_upload.created" webhook event.
    /// </summary>
    public class FileUploadCreatedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.FileUploadCreated;

        /// <summary>
        /// The file upload that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookFileUploadEntity Entity { get; set; }
    }

    /// <summary>
    /// Payload for the "file_upload.expired" webhook event.
    /// </summary>
    public class FileUploadExpiredWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.FileUploadExpired;

        /// <summary>
        /// The file upload that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookFileUploadEntity Entity { get; set; }
    }

    /// <summary>
    /// Payload for the "file_upload.upload_failed" webhook event.
    /// </summary>
    public class FileUploadUploadFailedWebhookPayload : WebhookPayload
    {
        /// <inheritdoc />
        public override WebhookEventType Type => WebhookEventType.FileUploadUploadFailed;

        /// <summary>
        /// The file upload that triggered the event.
        /// </summary>
        [JsonProperty("entity")]
        public WebhookFileUploadEntity Entity { get; set; }

        /// <summary>
        /// Additional event-specific data.
        /// </summary>
        [JsonProperty("data")]
        public FileUploadFailedData Data { get; set; }

        public class FileUploadFailedData
        {
            /// <summary>
            /// The result of the file import attempt.
            /// Discriminated by "type": "success" → <see cref="FileImportSuccessResult"/>,
            /// "error" → <see cref="FileImportErrorResult"/>.
            /// </summary>
            [JsonProperty("file_import_result")]
            public FileImportResult FileImportResult { get; set; }
        }
    }
}
