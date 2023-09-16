using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class NotionApiException : Exception
    {
        public NotionApiException(HttpStatusCode statusCode, NotionAPIErrorCode? notionAPIErrorCode, string message)
            : this(statusCode, notionAPIErrorCode, message, null)
        {
        }

        private NotionApiException(
            HttpStatusCode statusCode,
            NotionAPIErrorCode? notionAPIErrorCode,
            string message,
            Exception innerException) : base(message, innerException)
        {
            NotionAPIErrorCode = notionAPIErrorCode;
            StatusCode = statusCode;

            InitializeData();
        }

        private void InitializeData()
        {
            Data.Add("StatusCode", StatusCode);
            Data.Add("NotionApiErrorCode", NotionAPIErrorCode);
        }

        public NotionAPIErrorCode? NotionAPIErrorCode { get; }

        public HttpStatusCode StatusCode { get; }
    }
}
