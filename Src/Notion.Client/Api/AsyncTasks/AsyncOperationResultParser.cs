using Newtonsoft.Json.Linq;

namespace Notion.Client
{
    internal static class AsyncOperationResultParser
    {
        /// <summary>
        /// Turns a raw response into an <see cref="AsyncOperationResult{T}" />: an <c>async_task</c> object is
        /// returned as the task, anything else as the operation's normal result.
        /// </summary>
        internal static AsyncOperationResult<T> Parse<T>(JObject response)
        {
            if (response != null && (string)response["object"] == "async_task")
            {
                return new AsyncOperationResult<T> { AsyncTask = response.ToObject<AsyncTask>() };
            }

            return new AsyncOperationResult<T> { Result = response == null ? default : response.ToObject<T>() };
        }
    }
}
