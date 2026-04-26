using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class PagesClient : IPagesClient
    {
        public async Task<PageMarkdownResponse> RetrieveAsMarkdownAsync(
            RetrievePageAsMarkdownRequest request,
            CancellationToken cancellationToken = default)
        {
            var url = ApiEndpoints.PagesApiUrls.RetrieveAsMarkdown(request);

            var queryParameters = request as IRetrievePageAsMarkdownQueryParameters;

            var queryParams = new Dictionary<string, string>()
            {
                { "include_transcript", queryParameters.IncludeTranscript.ToString() },
            };

            return await _client.GetAsync<PageMarkdownResponse>(url, queryParams, cancellationToken: cancellationToken);
        }
    }
}
