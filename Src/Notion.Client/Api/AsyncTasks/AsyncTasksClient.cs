using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed class AsyncTasksClient : IAsyncTasksClient
    {
        private readonly IRestClient _restClient;

        public AsyncTasksClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<AsyncTask> RetrieveAsync(string taskId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(taskId))
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            return await _restClient.GetAsync<AsyncTask>(
                ApiEndpoints.AsyncTasksApiUrls.Retrieve(taskId),
                cancellationToken: cancellationToken
            );
        }
    }
}
