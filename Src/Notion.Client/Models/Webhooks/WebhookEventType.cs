using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion webhook event.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// Use the <c>const string</c> members (e.g. <see cref="CommentCreatedValue"/>) when referencing a value
    /// in a <c>[JsonSubtypes.KnownSubType]</c> attribute; use the <c>static readonly</c> fields
    /// (e.g. <see cref="CommentCreated"/>) everywhere else.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<WebhookEventType>))]
    public readonly struct WebhookEventType : IEquatable<WebhookEventType>
    {
        private readonly string _value;

        public WebhookEventType(string value) => _value = value;

        public const string CommentCreatedValue = "comment.created";
        public const string CommentUpdatedValue = "comment.updated";
        public const string CommentDeletedValue = "comment.deleted";

        public const string DataSourceContentUpdatedValue = "data_source.content_updated";
        public const string DataSourceCreatedValue = "data_source.created";
        public const string DataSourceDeletedValue = "data_source.deleted";
        public const string DataSourceMovedValue = "data_source.moved";
        public const string DataSourceSchemaUpdatedValue = "data_source.schema_updated";
        public const string DataSourceUndeletedValue = "data_source.undeleted";

        public const string DatabaseContentUpdatedValue = "database.content_updated";
        public const string DatabaseCreatedValue = "database.created";
        public const string DatabaseDeletedValue = "database.deleted";
        public const string DatabaseMovedValue = "database.moved";
        public const string DatabaseSchemaUpdatedValue = "database.schema_updated";
        public const string DatabaseUndeletedValue = "database.undeleted";

        public const string FileUploadCompletedValue = "file_upload.completed";
        public const string FileUploadCreatedValue = "file_upload.created";
        public const string FileUploadExpiredValue = "file_upload.expired";
        public const string FileUploadUploadFailedValue = "file_upload.upload_failed";

        public const string PageContentUpdatedValue = "page.content_updated";
        public const string PageCreatedValue = "page.created";
        public const string PageDeletedValue = "page.deleted";
        public const string PageLockedValue = "page.locked";
        public const string PageMovedValue = "page.moved";
        public const string PagePropertiesUpdatedValue = "page.properties_updated";
        public const string PageTranscriptionBlockTranscriptDeletedValue = "page.transcription_block.transcript_deleted";
        public const string PageUndeletedValue = "page.undeleted";
        public const string PageUnlockedValue = "page.unlocked";

        public const string ViewCreatedValue = "view.created";
        public const string ViewDeletedValue = "view.deleted";
        public const string ViewUpdatedValue = "view.updated";

        public static readonly WebhookEventType CommentCreated = new WebhookEventType(CommentCreatedValue);
        public static readonly WebhookEventType CommentUpdated = new WebhookEventType(CommentUpdatedValue);
        public static readonly WebhookEventType CommentDeleted = new WebhookEventType(CommentDeletedValue);

        public static readonly WebhookEventType DataSourceContentUpdated = new WebhookEventType(DataSourceContentUpdatedValue);
        public static readonly WebhookEventType DataSourceCreated = new WebhookEventType(DataSourceCreatedValue);
        public static readonly WebhookEventType DataSourceDeleted = new WebhookEventType(DataSourceDeletedValue);
        public static readonly WebhookEventType DataSourceMoved = new WebhookEventType(DataSourceMovedValue);
        public static readonly WebhookEventType DataSourceSchemaUpdated = new WebhookEventType(DataSourceSchemaUpdatedValue);
        public static readonly WebhookEventType DataSourceUndeleted = new WebhookEventType(DataSourceUndeletedValue);

        public static readonly WebhookEventType DatabaseContentUpdated = new WebhookEventType(DatabaseContentUpdatedValue);
        public static readonly WebhookEventType DatabaseCreated = new WebhookEventType(DatabaseCreatedValue);
        public static readonly WebhookEventType DatabaseDeleted = new WebhookEventType(DatabaseDeletedValue);
        public static readonly WebhookEventType DatabaseMoved = new WebhookEventType(DatabaseMovedValue);
        public static readonly WebhookEventType DatabaseSchemaUpdated = new WebhookEventType(DatabaseSchemaUpdatedValue);
        public static readonly WebhookEventType DatabaseUndeleted = new WebhookEventType(DatabaseUndeletedValue);

        public static readonly WebhookEventType FileUploadCompleted = new WebhookEventType(FileUploadCompletedValue);
        public static readonly WebhookEventType FileUploadCreated = new WebhookEventType(FileUploadCreatedValue);
        public static readonly WebhookEventType FileUploadExpired = new WebhookEventType(FileUploadExpiredValue);
        public static readonly WebhookEventType FileUploadUploadFailed = new WebhookEventType(FileUploadUploadFailedValue);

        public static readonly WebhookEventType PageContentUpdated = new WebhookEventType(PageContentUpdatedValue);
        public static readonly WebhookEventType PageCreated = new WebhookEventType(PageCreatedValue);
        public static readonly WebhookEventType PageDeleted = new WebhookEventType(PageDeletedValue);
        public static readonly WebhookEventType PageLocked = new WebhookEventType(PageLockedValue);
        public static readonly WebhookEventType PageMoved = new WebhookEventType(PageMovedValue);
        public static readonly WebhookEventType PagePropertiesUpdated = new WebhookEventType(PagePropertiesUpdatedValue);
        public static readonly WebhookEventType PageTranscriptionBlockTranscriptDeleted = new WebhookEventType(PageTranscriptionBlockTranscriptDeletedValue);
        public static readonly WebhookEventType PageUndeleted = new WebhookEventType(PageUndeletedValue);
        public static readonly WebhookEventType PageUnlocked = new WebhookEventType(PageUnlockedValue);

        public static readonly WebhookEventType ViewCreated = new WebhookEventType(ViewCreatedValue);
        public static readonly WebhookEventType ViewDeleted = new WebhookEventType(ViewDeletedValue);
        public static readonly WebhookEventType ViewUpdated = new WebhookEventType(ViewUpdatedValue);

        public static implicit operator WebhookEventType(string value) => new WebhookEventType(value);

        public static bool operator ==(WebhookEventType left, WebhookEventType right) => left.Equals(right);
        public static bool operator !=(WebhookEventType left, WebhookEventType right) => !left.Equals(right);

        public bool Equals(WebhookEventType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is WebhookEventType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
