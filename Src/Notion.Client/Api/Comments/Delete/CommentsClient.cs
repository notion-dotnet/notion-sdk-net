using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task DeleteAsync(
            string commentId,
            CancellationToken cancellationToken = default)
        {
            await _client.DeleteAsync(
                ApiEndpoints.CommentsApiUrls.Delete(commentId),
                cancellationToken: cancellationToken
            );
        }
    }
}
