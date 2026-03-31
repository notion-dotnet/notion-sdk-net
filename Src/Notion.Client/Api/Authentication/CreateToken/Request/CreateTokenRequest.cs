namespace Notion.Client
{
    public class CreateTokenRequest : ICreateTokenBodyParameters, IBasicAuthenticationParameters
    {
        public string GrantType => "authorization_code";

        public string Code { get; set; }

        public string RedirectUri { get; set; }

        public ExternalAccount ExternalAccount { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
