using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        Task<Comment> CreateAsync(CreateCommentRequest createCommentParameters, CancellationToken cancellationToken = default);

        Task<RetrieveCommentsResponse> RetrieveAsync(RetrieveCommentsRequest parameters, CancellationToken cancellationToken = default);
    }
}
