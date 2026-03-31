using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// Authentication client
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// Creates an access token that a third-party service can use to authenticate with Notion.
        /// </summary>
        /// <param name="createTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CreateTokenResponse> CreateTokenAsync(
            CreateTokenRequest createTokenRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Revokes an access token.
        /// </summary>
        /// <param name="revokeTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RevokeTokenAsync(
            RevokeTokenRequest revokeTokenRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Get a token's active status, scope, and issued time.
        /// </summary>
        /// <param name="introspectTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IntrospectTokenResponse> IntrospectTokenAsync(
            IntrospectTokenRequest introspectTokenRequest,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Refreshes an access token, generating a new access token and new refresh token.
        /// </summary>
        /// <param name="refreshTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RefreshTokenResponse> RefreshTokenAsync(
            RefreshTokenRequest refreshTokenRequest,
            CancellationToken cancellationToken = default
        );
    }
}
