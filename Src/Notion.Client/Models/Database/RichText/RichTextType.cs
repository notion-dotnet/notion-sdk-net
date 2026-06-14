using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion rich text object.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<RichTextType>))]
    public readonly struct RichTextType : IEquatable<RichTextType>
    {
        private readonly string _value;

        public RichTextType(string value) => _value = value;

        public const string TextValue = "text";
        public const string MentionValue = "mention";
        public const string EquationValue = "equation";

        public static readonly RichTextType Text = new RichTextType(TextValue);
        public static readonly RichTextType Mention = new RichTextType(MentionValue);
        public static readonly RichTextType Equation = new RichTextType(EquationValue);

        public static implicit operator RichTextType(string value) => new RichTextType(value);

        public static bool operator ==(RichTextType left, RichTextType right) => left.Equals(right);
        public static bool operator !=(RichTextType left, RichTextType right) => !left.Equals(right);

        public bool Equals(RichTextType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is RichTextType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
