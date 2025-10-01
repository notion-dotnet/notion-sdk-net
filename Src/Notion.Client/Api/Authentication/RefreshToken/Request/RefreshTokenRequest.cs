namespace Notion.Client
{
    public class RefreshTokenRequest : IRefreshTokenBodyParameters, IBasicAuthenticationParameters
    {
        public string GrantType { get; set; } = "refresh_token";

        public string RefreshToken { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
