using System.Collections.Generic;

namespace Notion.Client
{
    /// <summary>
    /// Per-request overrides for <see cref="INotionClient.RequestAsync{T}" />.
    /// </summary>
    public class ClientRequestOptions
    {
        /// <summary>
        /// Token to use for this request instead of <see cref="ClientOptions.AuthToken" /> (sent as a Bearer token).
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Extra headers for this request. <c>Authorization</c> and <c>Notion-Version</c> replace the client's values.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }
    }
}
