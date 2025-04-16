using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class AuthenticationClient
    {
        public async Task RevokeTokenAsync(
            RevokeTokenRequest revokeTokenRequest,
            CancellationToken cancellationToken = default)
        {
            var body = (IRevokeTokenBodyParameters)revokeTokenRequest;

            var response = await _client.PostAsync<HttpResponseMessage>(
                ApiEndpoints.AuthenticationUrls.RevokeToken(),
                body,
                cancellationToken: cancellationToken
            );

            if (!response.IsSuccessStatusCode)
            {
                throw new NotionApiException(response.StatusCode,
                    null,
                    "None success status code returned from revoke endpoint"
                );
            }
        }
    }
}
