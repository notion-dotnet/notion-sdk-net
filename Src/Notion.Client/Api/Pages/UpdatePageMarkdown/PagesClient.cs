using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class PagesClient
    {
        /// <inheritdoc />
        public async Task<PageMarkdownResponse> UpdateMarkdownAsync(
            string pageId,
            UpdatePageMarkdownBody body,
            CancellationToken cancellationToken = default)
        {
            if (pageId is null)
            {
                throw new ArgumentNullException(nameof(pageId));
            }

            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            var url = ApiEndpoints.PagesApiUrls.UpdateMarkdown(pageId);

            return await _client.PatchAsync<PageMarkdownResponse>(url, body, cancellationToken: cancellationToken);
        }
    }
}
