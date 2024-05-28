namespace Notion.Client
{
    public class CreateTokenRequest : ICreateTokenBodyParameters
    {
        public string GrantType => "authorization_code";

        public string Code { get; set; }

        public string RedirectUri { get; set; }

        public ExternalAccount ExternalAccount { get; set; }
    }
}
