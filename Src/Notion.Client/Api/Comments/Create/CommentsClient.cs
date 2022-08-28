using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<CreateCommentResponse> Create(CreateCommentParameters parameters)
        {
            var body = (ICreateCommentsBodyParameters)parameters;

            return await _client.PostAsync<CreateCommentResponse>(
                ApiEndpoints.CommentsApiUrls.Create(),
                body
            );
        }
    }
}
