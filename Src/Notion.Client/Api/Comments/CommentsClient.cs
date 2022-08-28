namespace Notion.Client
{
    public partial class CommentsClient : ICommentsClient
    {
        private readonly IRestClient _client;

        public CommentsClient(IRestClient restClient)
        {
            _client = restClient;
        }
    }
}
