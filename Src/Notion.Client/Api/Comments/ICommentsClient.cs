using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        Task<CreateCommentResponse> CreateAsync(CreateCommentParameters createCommentParameters);

        Task<RetrieveCommentsResponse> RetrieveAsync(RetrieveCommentsParameters parameters);
    }
}
