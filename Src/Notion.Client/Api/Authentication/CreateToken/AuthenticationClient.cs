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
            var body = (ICreateTokenBodyParameters)createTokenRequest;

            return await _client.PostAsync<CreateTokenResponse>(
                ApiEndpoints.AuthenticationUrls.CreateToken(),
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
