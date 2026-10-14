using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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

            if (body.AllowAsync == true)
            {
                throw new ArgumentException(
                    "AllowAsync is only supported by UpdateMarkdownWithAsyncTaskAsync.",
                    nameof(body));
            }

            var url = ApiEndpoints.PagesApiUrls.UpdateMarkdown(pageId);

            return await _client.PatchAsync<PageMarkdownResponse>(url, body, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public async Task<AsyncOperationResult<PageMarkdownResponse>> UpdateMarkdownWithAsyncTaskAsync(
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

            body.AllowAsync = true;

            var url = ApiEndpoints.PagesApiUrls.UpdateMarkdown(pageId);
            var response = await _client.PatchAsync<JObject>(url, body, cancellationToken: cancellationToken);

            return AsyncOperationResultParser.Parse<PageMarkdownResponse>(response);
        }
    }
}
