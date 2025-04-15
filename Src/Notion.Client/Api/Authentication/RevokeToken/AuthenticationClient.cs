using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class AuthenticationClient
    {   
        public async Task<HttpStatusCode> RevokeTokenAsync(
            RevokeTokenRequest revokeTokenRequest,
            CancellationToken cancellationToken = default)
        {
            var body = (IRevokeTokenBodyParameters)revokeTokenRequest;
            
            return (await _client.PostAsync(
                ApiEndpoints.AuthenticationUrls.RevokeToken(),
                body,
                cancellationToken: cancellationToken
            )).StatusCode;
        }
    }
}
