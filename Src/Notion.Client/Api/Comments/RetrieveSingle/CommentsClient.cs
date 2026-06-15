using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<Comment> RetrieveSingleAsync(
            RetrieveSingleCommentRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<Comment>(
                ApiEndpoints.CommentsApiUrls.RetrieveSingle(request.CommentId),
                cancellationToken: cancellationToken
            );
        }
    }
}
