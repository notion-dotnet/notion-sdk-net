using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IAsyncTasksClient
    {
        /// <summary>
        /// Retrieves an async task, e.g. to poll an operation that was started with <c>allow_async</c>.
        /// </summary>
        /// <param name="taskId">The ID of the async task.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<AsyncTask> RetrieveAsync(string taskId, CancellationToken cancellationToken = default);
    }
}
