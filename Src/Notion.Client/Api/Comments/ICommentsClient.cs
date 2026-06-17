using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ICommentsClient
    {
        Task<Comment> CreateAsync(CreateCommentRequest createCommentParameters, CancellationToken cancellationToken = default);

        Task<RetrieveCommentsResponse> RetrieveAsync(RetrieveCommentsRequest parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a single comment by its ID.
        /// </summary>
        Task<Comment> RetrieveSingleAsync(RetrieveSingleCommentRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a comment's rich_text content.
        /// </summary>
        Task<Comment> UpdateAsync(UpdateCommentRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a comment by its ID.
        /// </summary>
        Task DeleteAsync(string commentId, CancellationToken cancellationToken = default);
    }
}
