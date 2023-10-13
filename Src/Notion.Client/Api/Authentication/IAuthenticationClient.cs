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
    }
}
