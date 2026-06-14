using System.Net.Http;

namespace Notion.Client
{
    public class ClientOptions
    {
        public string BaseUrl { get; set; }

        public string NotionVersion { get; set; }

        public string AuthToken { get; set; }

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
