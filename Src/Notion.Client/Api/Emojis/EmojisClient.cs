namespace Notion.Client
{
    public sealed partial class EmojisClient : IEmojisClient
    {
        private readonly IRestClient _restClient;

        public EmojisClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
