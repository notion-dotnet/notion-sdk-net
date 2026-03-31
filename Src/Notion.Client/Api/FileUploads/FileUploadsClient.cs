namespace Notion.Client
{
    public sealed partial class FileUploadsClient : IFileUploadsClient
    {
        private readonly IRestClient _restClient;

        public FileUploadsClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
