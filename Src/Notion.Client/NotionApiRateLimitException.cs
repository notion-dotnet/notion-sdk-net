using System;
using System.Net;

namespace Notion.Client
{
    public sealed class NotionApiRateLimitException : NotionApiException
    {
        public TimeSpan? RetryAfter { get; }

        public NotionApiRateLimitException(
            HttpStatusCode statusCode,
            NotionAPIErrorCode? notionAPIErrorCode,
            string message,
            TimeSpan? retryAfter)
            : base(statusCode, notionAPIErrorCode, message)
        {
            RetryAfter = retryAfter;

            Data.Add("RetryAfter", retryAfter);
        }
    }
}
