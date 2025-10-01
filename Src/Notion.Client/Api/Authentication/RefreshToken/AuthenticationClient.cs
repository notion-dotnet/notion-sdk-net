using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class AuthenticationClient
    {
        public async Task<RefreshTokenResponse> RefreshTokenAsync(
            RefreshTokenRequest refreshTokenRequest,
            CancellationToken cancellationToken = default)
        {
            if (refreshTokenRequest == null)
            {
                throw new ArgumentNullException(nameof(refreshTokenRequest));
            }

            IRefreshTokenBodyParameters body = refreshTokenRequest;

            if (string.IsNullOrWhiteSpace(body.RefreshToken))
            {
                throw new ArgumentNullException(nameof(body.RefreshToken), "RefreshToken is required.");
            }

            IBasicAuthenticationParameters basicAuth = refreshTokenRequest;

            BasicAuthParamValidator.Validate(basicAuth);

            var response = await _client.PostAsync<RefreshTokenResponse>(
                ApiEndpoints.AuthenticationUrls.RefreshToken(),
                body,
                basicAuthenticationParameters: basicAuth,
                cancellationToken: cancellationToken
            );

            return response;
        }
    }
}
