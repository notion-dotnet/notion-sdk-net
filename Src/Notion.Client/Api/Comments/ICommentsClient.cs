using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        /// <summary>
        /// Retrieves a list of un-resolved Comment objects from a page or block.
        /// </summary>
        /// <param name="retrieveCommentsParameters">Retrieve comments parameters</param>
        /// <returns><see cref="RetrieveCommentsResponse"/></returns>
        Task<RetrieveCommentsResponse> Retrieve(RetrieveCommentsParameters retrieveCommentsParameters);

        Task<CreateCommentResponse> Create(CreateCommentParameters createCommentParameters);
    }
}
