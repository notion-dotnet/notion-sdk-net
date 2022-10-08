using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        Task<CreateCommentResponse> Create(CreateCommentParameters createCommentParameters);

        Task<RetrieveCommentsResponse> Retrieve(RetrieveCommentsParameters parameters);
    }
}
