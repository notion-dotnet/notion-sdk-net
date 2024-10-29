using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum NotionAPIErrorCode
    {
        [EnumMember(Value = "invalid_json")]
        InvalidJSON,

        [EnumMember(Value = "invalid_request_url")]
        InvalidRequestUrl,

        [EnumMember(Value = "invalid_request")]
        InvalidRequest,

        [EnumMember(Value = "invalid_grant")]
        InvalidGrant,

        [EnumMember(Value = "validation_error")]
        ValidationError,

        [EnumMember(Value = "missing_version")]
        MissingVersion,

        [EnumMember(Value = "unauthorized")]
        Unauthorized,

        [EnumMember(Value = "restricted_resource")]
        RestrictedResource,

        [EnumMember(Value = "object_not_found")]
        ObjectNotFound,

        [EnumMember(Value = "conflict_error")]
        ConflictError,

        [EnumMember(Value = "rate_limited")]
        RateLimited,

        [EnumMember(Value = "internal_server_error")]
        InternalServerError,

        [EnumMember(Value = "bad_gateway")]
        BadGateway,

        [EnumMember(Value = "service_unavailable")]
        ServiceUnavailable,

        [EnumMember(Value = "database_connection_unavailable")]
        DatabaseConnectionUnavailable,

        [EnumMember(Value = "gateway_timeout")]
        GatewayTimeout
    }
}
