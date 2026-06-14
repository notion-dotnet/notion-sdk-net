using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents a Notion API error code.
    /// New codes introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<NotionAPIErrorCode>))]
    public readonly struct NotionAPIErrorCode : IEquatable<NotionAPIErrorCode>
    {
        private readonly string _value;

        public NotionAPIErrorCode(string value) => _value = value;

        public const string InvalidJSONValue = "invalid_json";
        public const string InvalidRequestUrlValue = "invalid_request_url";
        public const string InvalidRequestValue = "invalid_request";
        public const string InvalidGrantValue = "invalid_grant";
        public const string ValidationErrorValue = "validation_error";
        public const string MissingVersionValue = "missing_version";
        public const string UnauthorizedValue = "unauthorized";
        public const string RestrictedResourceValue = "restricted_resource";
        public const string ObjectNotFoundValue = "object_not_found";
        public const string ConflictErrorValue = "conflict_error";
        public const string RateLimitedValue = "rate_limited";
        public const string InternalServerErrorValue = "internal_server_error";
        public const string BadGatewayValue = "bad_gateway";
        public const string ServiceUnavailableValue = "service_unavailable";
        public const string DatabaseConnectionUnavailableValue = "database_connection_unavailable";
        public const string GatewayTimeoutValue = "gateway_timeout";

        public static readonly NotionAPIErrorCode InvalidJSON = new NotionAPIErrorCode(InvalidJSONValue);
        public static readonly NotionAPIErrorCode InvalidRequestUrl = new NotionAPIErrorCode(InvalidRequestUrlValue);
        public static readonly NotionAPIErrorCode InvalidRequest = new NotionAPIErrorCode(InvalidRequestValue);
        public static readonly NotionAPIErrorCode InvalidGrant = new NotionAPIErrorCode(InvalidGrantValue);
        public static readonly NotionAPIErrorCode ValidationError = new NotionAPIErrorCode(ValidationErrorValue);
        public static readonly NotionAPIErrorCode MissingVersion = new NotionAPIErrorCode(MissingVersionValue);
        public static readonly NotionAPIErrorCode Unauthorized = new NotionAPIErrorCode(UnauthorizedValue);
        public static readonly NotionAPIErrorCode RestrictedResource = new NotionAPIErrorCode(RestrictedResourceValue);
        public static readonly NotionAPIErrorCode ObjectNotFound = new NotionAPIErrorCode(ObjectNotFoundValue);
        public static readonly NotionAPIErrorCode ConflictError = new NotionAPIErrorCode(ConflictErrorValue);
        public static readonly NotionAPIErrorCode RateLimited = new NotionAPIErrorCode(RateLimitedValue);
        public static readonly NotionAPIErrorCode InternalServerError = new NotionAPIErrorCode(InternalServerErrorValue);
        public static readonly NotionAPIErrorCode BadGateway = new NotionAPIErrorCode(BadGatewayValue);
        public static readonly NotionAPIErrorCode ServiceUnavailable = new NotionAPIErrorCode(ServiceUnavailableValue);
        public static readonly NotionAPIErrorCode DatabaseConnectionUnavailable = new NotionAPIErrorCode(DatabaseConnectionUnavailableValue);
        public static readonly NotionAPIErrorCode GatewayTimeout = new NotionAPIErrorCode(GatewayTimeoutValue);

        public static implicit operator NotionAPIErrorCode(string value) => new NotionAPIErrorCode(value);

        public static bool operator ==(NotionAPIErrorCode left, NotionAPIErrorCode right) => left.Equals(right);
        public static bool operator !=(NotionAPIErrorCode left, NotionAPIErrorCode right) => !left.Equals(right);

        public bool Equals(NotionAPIErrorCode other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is NotionAPIErrorCode other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
