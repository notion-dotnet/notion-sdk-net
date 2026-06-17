using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<Comment> UpdateAsync(
            UpdateCommentRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _client.PatchAsync<Comment>(
                ApiEndpoints.CommentsApiUrls.Update(request.CommentId),
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
