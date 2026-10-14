using System.Net;

namespace Notion.Client
{
    /// <summary>
    /// Thrown when the API (or a proxy in front of it) returns an error status whose body is not a Notion
    /// error object, e.g. an HTML error page from Cloudflare. Derives from <see cref="NotionApiException" />,
    /// so existing <c>catch (NotionApiException)</c> blocks still handle it; <see cref="NotionApiException.NotionAPIErrorCode" />
    /// is <c>null</c>.
    /// </summary>
    public sealed class NotionUnknownResponseException : NotionApiException
    {
        public NotionUnknownResponseException(HttpStatusCode statusCode, string message)
            : base(statusCode, null, message)
        {
        }
    }
}
