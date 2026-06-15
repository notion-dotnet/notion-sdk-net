using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IEmojisClient
    {
        /// <summary>
        /// List all custom emojis available in the workspace.
        /// </summary>
        /// <param name="request">Pagination parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A paginated list of custom emojis.</returns>
        Task<ListEmojisResponse> ListAsync(
            ListEmojisRequest request,
            CancellationToken cancellationToken = default
        );
    }
}
