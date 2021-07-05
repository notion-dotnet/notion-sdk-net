using System;
using System.Net;

namespace Notion.Client
{
    public class NotionApiException : Exception
    {
        public NotionApiException(HttpStatusCode statusCode, NotionAPIErrorCode? notionAPIErrorCode, string message)
            : this(statusCode, notionAPIErrorCode, message, null)
        {
        }

        public NotionApiException(HttpStatusCode statusCode, string message)
            : this(statusCode, null, message, null)
        {
        }

        public NotionApiException(
            HttpStatusCode statusCode,
            NotionAPIErrorCode? notionAPIErrorCode,
            string message,
            Exception innerException) : base(message, innerException)
        {
            NotionAPIErrorCode = notionAPIErrorCode;
            StatusCode = statusCode;

            Data.Add("StatusCode", statusCode);
            Data.Add("NotionApiErrorCode", NotionAPIErrorCode);
        }

        public NotionAPIErrorCode? NotionAPIErrorCode { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
