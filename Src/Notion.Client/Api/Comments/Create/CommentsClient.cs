using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<CreateCommentResponse> CreateAsync(CreateCommentParameters parameters, CancellationToken cancellationToken = default)
        {
            var body = (ICreateCommentsBodyParameters)parameters;

            return await _client.PostAsync<CreateCommentResponse>(
                ApiEndpoints.CommentsApiUrls.Create(),
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
