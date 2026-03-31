using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<Comment> CreateAsync(CreateCommentRequest parameters, CancellationToken cancellationToken = default)
        {
            var body = (ICreateCommentsBodyParameters)parameters;

            return await _client.PostAsync<Comment>(
                ApiEndpoints.CommentsApiUrls.Create(),
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
