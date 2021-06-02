using System;
using System.Net;

namespace Notion.Client
{
    class NotionApiException : Exception
    {
        public NotionApiException(HttpStatusCode statusCode, string message) : this(statusCode, message, null)
        {
        }

        public NotionApiException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            Data.Add("StatusCode", statusCode);
        }
    }
}
