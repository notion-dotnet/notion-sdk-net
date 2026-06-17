using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// The numbering style for a numbered list item block.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<NumberedListFormat>))]
    public readonly struct NumberedListFormat : IEquatable<NumberedListFormat>
    {
        private readonly string _value;

        public NumberedListFormat(string value) => _value = value;

        public const string NumbersValue = "numbers";
        public const string LettersValue = "letters";
        public const string RomanValue = "roman";

        public static readonly NumberedListFormat Numbers = new NumberedListFormat(NumbersValue);
        public static readonly NumberedListFormat Letters = new NumberedListFormat(LettersValue);
        public static readonly NumberedListFormat Roman = new NumberedListFormat(RomanValue);

        public static implicit operator NumberedListFormat(string value) => new NumberedListFormat(value);

        public static bool operator ==(NumberedListFormat left, NumberedListFormat right) => left.Equals(right);
        public static bool operator !=(NumberedListFormat left, NumberedListFormat right) => !left.Equals(right);

        public bool Equals(NumberedListFormat other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is NumberedListFormat other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
