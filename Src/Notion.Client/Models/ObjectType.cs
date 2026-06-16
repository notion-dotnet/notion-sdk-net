using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the Notion object type discriminator.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<ObjectType>))]
    public readonly struct ObjectType : IEquatable<ObjectType>
    {
        private readonly string _value;

        public ObjectType(string value) => _value = value;

        public const string PageValue = "page";
        public const string DatabaseValue = "database";
        public const string BlockValue = "block";
        public const string UserValue = "user";
        public const string CommentValue = "comment";
        public const string FileUploadValue = "file_upload";
        public const string DataSourceValue = "data_source";
        public const string PageMarkdownValue = "page_markdown";
        public const string ViewValue = "view";

        public static readonly ObjectType Page = new ObjectType(PageValue);
        public static readonly ObjectType Database = new ObjectType(DatabaseValue);
        public static readonly ObjectType Block = new ObjectType(BlockValue);
        public static readonly ObjectType User = new ObjectType(UserValue);
        public static readonly ObjectType Comment = new ObjectType(CommentValue);
        public static readonly ObjectType FileUpload = new ObjectType(FileUploadValue);
        public static readonly ObjectType DataSource = new ObjectType(DataSourceValue);
        public static readonly ObjectType PageMarkdown = new ObjectType(PageMarkdownValue);
        public static readonly ObjectType View = new ObjectType(ViewValue);

        public static implicit operator ObjectType(string value) => new ObjectType(value);

        public static bool operator ==(ObjectType left, ObjectType right) => left.Equals(right);
        public static bool operator !=(ObjectType left, ObjectType right) => !left.Equals(right);

        public bool Equals(ObjectType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is ObjectType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
