using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface INotionClient
    {
        IAuthenticationClient AuthenticationClient { get; }

        IUsersClient Users { get; }

        IDatabasesClient Databases { get; }

        IPagesClient Pages { get; }

        ISearchClient Search { get; }

        IBlocksClient Blocks { get; }

        ICommentsClient Comments { get; }

        IFileUploadsClient FileUploads { get; }

        IDataSourcesClient DataSources { get; }

        IViewsClient Views { get; }

        IEmojisClient Emojis { get; }

        IRestClient RestClient { get; }

        /// <summary>
        /// Sends a request to any Notion API endpoint, for endpoints the SDK does not model yet.
        /// </summary>
        /// <typeparam name="T">Type to deserialize the response into, e.g. <c>JObject</c>.</typeparam>
        /// <param name="method">GET, POST, PATCH or DELETE.</param>
        /// <param name="path">Path starting with <c>/v1/</c>, e.g. <c>/v1/users/me</c>.</param>
        /// <param name="body">JSON body; ignored for GET and DELETE.</param>
        /// <param name="query">Query string parameters (a key may repeat).</param>
        /// <param name="options">Per-request auth token and header overrides.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            object body = null,
            IEnumerable<KeyValuePair<string, string>> query = null,
            ClientRequestOptions options = null,
            CancellationToken cancellationToken = default);
    }

    public class NotionClient : INotionClient
    {
        public NotionClient(
            IRestClient restClient,
            IUsersClient users,
            IDatabasesClient databases,
            IPagesClient pages,
            ISearchClient search,
            ICommentsClient comments,
            IBlocksClient blocks,
            IAuthenticationClient authenticationClient,
            IFileUploadsClient fileUploadsClient,
            IDataSourcesClient dataSourcesClient,
            IViewsClient viewsClient,
            IEmojisClient emojisClient)
        {
            RestClient = restClient;
            Users = users;
            Databases = databases;
            Pages = pages;
            Search = search;
            Comments = comments;
            Blocks = blocks;
            AuthenticationClient = authenticationClient;
            FileUploads = fileUploadsClient;
            DataSources = dataSourcesClient;
            Views = viewsClient;
            Emojis = emojisClient;
        }

        public IAuthenticationClient AuthenticationClient { get; }

        public IUsersClient Users { get; }

        public IDatabasesClient Databases { get; }

        public IPagesClient Pages { get; }

        public ISearchClient Search { get; }

        public IBlocksClient Blocks { get; }

        public ICommentsClient Comments { get; }

        public IFileUploadsClient FileUploads { get; }

        public IDataSourcesClient DataSources { get; }

        public IViewsClient Views { get; }

        public IEmojisClient Emojis { get; }

        public IRestClient RestClient { get; }

        public async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            object body = null,
            IEnumerable<KeyValuePair<string, string>> query = null,
            ClientRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var uri = AppendQuery(path, query);

            var headers = options?.Headers == null
                ? new Dictionary<string, string>()
                : new Dictionary<string, string>(options.Headers);

            if (!string.IsNullOrEmpty(options?.AuthToken))
            {
                headers["Authorization"] = "Bearer " + options.AuthToken;
            }

            if (method == HttpMethod.Get)
            {
                return await RestClient.GetAsync<T>(uri, headers: headers, cancellationToken: cancellationToken);
            }

            if (method == HttpMethod.Post)
            {
                return await RestClient.PostAsync<T>(uri, body, headers: headers, cancellationToken: cancellationToken);
            }

            if (method.Method == "PATCH")
            {
                return await RestClient.PatchAsync<T>(uri, body, headers: headers, cancellationToken: cancellationToken);
            }

            if (method == HttpMethod.Delete)
            {
                return await RestClient.DeleteAsync<T>(uri, headers: headers, cancellationToken: cancellationToken);
            }

            throw new NotSupportedException("Only GET, POST, PATCH and DELETE are supported.");
        }

        private static string AppendQuery(string path, IEnumerable<KeyValuePair<string, string>> query)
        {
            var pairs = query?
                .Where(x => x.Value != null)
                .Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value))
                .ToList();

            if (pairs == null || pairs.Count == 0)
            {
                return path;
            }

            return path + (path.Contains("?") ? "&" : "?") + string.Join("&", pairs);
        }
    }
}
