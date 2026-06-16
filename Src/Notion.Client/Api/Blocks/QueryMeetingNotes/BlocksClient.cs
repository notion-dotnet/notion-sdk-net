using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class BlocksClient
    {
        public async Task<QueryMeetingNotesResponse> QueryMeetingNotesAsync(
            QueryMeetingNotesRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _client.PostAsync<QueryMeetingNotesResponse>(
                ApiEndpoints.BlocksApiUrls.QueryMeetingNotes(),
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
