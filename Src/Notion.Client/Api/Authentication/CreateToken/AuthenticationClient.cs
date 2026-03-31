using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class AuthenticationClient
    {
        public async Task<CreateTokenResponse> CreateTokenAsync(
            CreateTokenRequest createTokenRequest,
            CancellationToken cancellationToken = default)
        {
            ICreateTokenBodyParameters body = createTokenRequest;
            IBasicAuthenticationParameters basicAuth = createTokenRequest;

            return await _client.PostAsync<CreateTokenResponse>(
                ApiEndpoints.AuthenticationUrls.CreateToken(),
                body,
                basicAuthenticationParameters: basicAuth,
                cancellationToken: cancellationToken
            );
        }
    }
}
