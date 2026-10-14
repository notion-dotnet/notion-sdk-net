using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// A background operation, returned when an endpoint is called with <c>allow_async</c> and the work
    /// is accepted for background execution. Poll it with <see cref="IAsyncTasksClient.RetrieveAsync" />.
    /// </summary>
    public class AsyncTask
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// URL to poll for the task status.
        /// </summary>
        [JsonProperty("status_url")]
        public string StatusUrl { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("operation")]
        public AsyncTaskOperation Operation { get; set; }

        /// <summary>
        /// One of <see cref="AsyncTaskStatus" />.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Suggested delay before polling again; set while the task is queued, running or retrying.
        /// </summary>
        [JsonProperty("poll_after_seconds")]
        public int? PollAfterSeconds { get; set; }

        /// <summary>
        /// The operation's response body; set when <see cref="Status" /> is <c>succeeded</c>.
        /// </summary>
        [JsonProperty("result")]
        public Dictionary<string, object> Result { get; set; }

        /// <summary>
        /// Set when <see cref="Status" /> is <c>failed</c>.
        /// </summary>
        [JsonProperty("error")]
        public AsyncTaskError Error { get; set; }

        [JsonIgnore]
        public bool IsFinished => Status == AsyncTaskStatus.Succeeded || Status == AsyncTaskStatus.Failed;
    }

    public static class AsyncTaskStatus
    {
        public const string Queued = "queued";
        public const string Running = "running";
        public const string Retrying = "retrying";
        public const string Succeeded = "succeeded";
        public const string Failed = "failed";
    }

    public class AsyncTaskOperation
    {
        /// <summary>
        /// "rest" or "mcp".
        /// </summary>
        [JsonProperty("surface")]
        public string Surface { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AsyncTaskError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The HTTP status the operation would have returned.
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("additional_data")]
        public Dictionary<string, object> AdditionalData { get; set; }
    }

    /// <summary>
    /// Result of an operation called with <c>allow_async</c>: either the normal <see cref="Result" />, or an
    /// <see cref="AsyncTask" /> to poll when the work was accepted for background execution.
    /// </summary>
    public class AsyncOperationResult<T>
    {
        public AsyncTask AsyncTask { get; set; }

        public T Result { get; set; }

        public bool IsAsync => AsyncTask != null;
    }
}
