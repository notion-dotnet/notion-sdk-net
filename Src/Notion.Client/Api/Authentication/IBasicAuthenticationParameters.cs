namespace Notion.Client
{
    public interface IBasicAuthenticationParameters
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
