namespace Notion.Client
{
    public class RevokeTokenRequest : IRevokeTokenBodyParameters, IBasicAuthenticationParameters
    {
        public string Token { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
