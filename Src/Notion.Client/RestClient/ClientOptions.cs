using System.Net.Http;

namespace Notion.Client
{
    public class ClientOptions
    {
        public string BaseUrl { get; set; }

        public string NotionVersion { get; set; }

        public string AuthToken { get; set; }

        /// <summary>
        /// Retry policy for failed requests. When <c>null</c> (default), a <see cref="DefaultRetryPolicy"/>
        /// is used: up to 2 retries with exponential backoff for 429/529 (and 500/503 on GET and DELETE),
        /// honouring <c>Retry-After</c>. File uploads are never retried because the upload stream cannot be replayed.
        /// Set <see cref="NoRetryPolicy.Instance"/> to disable retries, pass your own
        /// <see cref="DefaultRetryPolicy"/> to tune them, or implement <see cref="IRetryPolicy"/> for a custom strategy.
        /// The retry logic is applied at the <c>RestClient</c> level, so it works regardless of whether
        /// <see cref="HttpClient"/> is provided externally or created internally.
        /// <para>
        /// <b>Avoid configuring retry in two places.</b> If the <see cref="HttpClient"/> you supply already
        /// has retry behaviour in its pipeline (e.g. via Polly registered through
        /// <see cref="System.Net.Http.IHttpClientFactory"/>), set <see cref="NoRetryPolicy.Instance"/> here.
        /// Otherwise the retries are nested.
        /// </para>
        /// </summary>
        public IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// An <see cref="HttpClient"/> instance to use for all requests.
        /// When provided, the library uses it as-is and does not dispose it — the caller owns the lifetime.
        /// When null (default), the library creates and manages its own <see cref="HttpClient"/>.
        /// <para>
        /// For ASP.NET Core applications, prefer <c>AddNotionClient</c> on <c>IServiceCollection</c>,
        /// which integrates with <see cref="System.Net.Http.IHttpClientFactory"/> automatically.
        /// For console or non-DI applications, you may pass a long-lived singleton <see cref="HttpClient"/>
        /// or leave this null to let the library manage one.
        /// </para>
        /// </summary>
        public HttpClient HttpClient { get; set; }
    }
}
