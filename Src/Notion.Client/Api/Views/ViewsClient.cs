namespace Notion.Client
{
    public sealed partial class ViewsClient : IViewsClient
    {
        private readonly IRestClient _restClient;

        public ViewsClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
