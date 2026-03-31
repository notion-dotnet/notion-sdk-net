using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class AuthenticationClient
    {
        public async Task<IntrospectTokenResponse> IntrospectTokenAsync(
            IntrospectTokenRequest introspectTokenRequest,
            CancellationToken cancellationToken = default)
        {
            if (introspectTokenRequest is null)
            {
                throw new ArgumentNullException(nameof(introspectTokenRequest));
            }

            IIntrospectTokenBodyParameters body = introspectTokenRequest;
            IBasicAuthenticationParameters basicAuth = introspectTokenRequest;

            if (string.IsNullOrWhiteSpace(body.Token))
            {
                throw new ArgumentException("Token must be provided.", nameof(body.Token));
            }

            BasicAuthParamValidator.Validate(basicAuth);

            return await _client.PostAsync<IntrospectTokenResponse>(
                ApiEndpoints.AuthenticationUrls.IntrospectToken(),
                body,
                basicAuthenticationParameters: basicAuth,
                cancellationToken: cancellationToken
            );
        }
    }
}
