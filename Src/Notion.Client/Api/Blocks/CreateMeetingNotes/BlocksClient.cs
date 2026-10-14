using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class BlocksClient
    {
        public async Task<CreateMeetingNotesResponse> CreateMeetingNotesAsync(
            CreateMeetingNotesRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Source == null)
            {
                throw new ArgumentNullException(nameof(request.Source), "Source is required.");
            }

            return await _client.PostAsync<CreateMeetingNotesResponse>(
                ApiEndpoints.BlocksApiUrls.CreateMeetingNotes(),
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
