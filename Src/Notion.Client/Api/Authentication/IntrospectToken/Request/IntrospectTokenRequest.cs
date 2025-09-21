namespace Notion.Client
{
    public class IntrospectTokenRequest : IIntrospectTokenBodyParameters, IBasicAuthenticationParameters
    {
        public string Token { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
