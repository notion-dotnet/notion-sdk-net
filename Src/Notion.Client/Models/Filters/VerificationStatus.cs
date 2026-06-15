using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the verification status of a Notion page.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<VerificationStatus>))]
    public readonly struct VerificationStatus : IEquatable<VerificationStatus>
    {
        private readonly string _value;

        public VerificationStatus(string value) => _value = value;

        public const string VerifiedValue = "verified";
        public const string UnverifiedValue = "unverified";
        public const string ExpiredValue = "expired";
        public const string NoneValue = "none";

        public static readonly VerificationStatus Verified = new VerificationStatus(VerifiedValue);
        public static readonly VerificationStatus Unverified = new VerificationStatus(UnverifiedValue);
        public static readonly VerificationStatus Expired = new VerificationStatus(ExpiredValue);
        public static readonly VerificationStatus None = new VerificationStatus(NoneValue);

        public static implicit operator VerificationStatus(string value) => new VerificationStatus(value);

        public static bool operator ==(VerificationStatus left, VerificationStatus right) => left.Equals(right);
        public static bool operator !=(VerificationStatus left, VerificationStatus right) => !left.Equals(right);

        public bool Equals(VerificationStatus other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is VerificationStatus other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
