using System;
using System.Collections.Generic;
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

        /// <summary>
        /// The request id reported by Notion (<c>request_id</c> in the body, else the <c>x-notion-request-id</c>
        /// header). Include it when contacting Notion support.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// The Cloudflare Ray ID (<c>cf-ray</c> header) when the response came through Notion's edge proxy.
        /// </summary>
        public string RayId { get; internal set; }

        /// <summary>
        /// Extra data returned with the error (<c>additional_data</c>), if any.
        /// </summary>
        public IReadOnlyDictionary<string, object> AdditionalData { get; internal set; }

        /// <summary>
        /// The raw response body.
        /// </summary>
        public string ResponseBody { get; internal set; }

        /// <summary>
        /// The response headers; multiple values of a header are joined with ", ".
        /// </summary>
        public IReadOnlyDictionary<string, string> ResponseHeaders { get; internal set; }
    }
}
