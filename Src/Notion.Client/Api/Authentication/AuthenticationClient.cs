namespace Notion.Client
{
    public sealed partial class AuthenticationClient : IAuthenticationClient
    {
        private readonly IRestClient _client;

        public AuthenticationClient(IRestClient restClient)
        {
            _client = restClient;
        }
    }
}
