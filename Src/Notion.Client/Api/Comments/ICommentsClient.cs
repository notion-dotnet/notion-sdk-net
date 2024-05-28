using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        Task<CreateCommentResponse> CreateAsync(CreateCommentParameters createCommentParameters, CancellationToken cancellationToken = default);

        Task<RetrieveCommentsResponse> RetrieveAsync(RetrieveCommentsParameters parameters, CancellationToken cancellationToken = default);
    }
}
