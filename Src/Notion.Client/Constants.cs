using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Notion.UnitTests")]

namespace Notion.Client
{
    internal static class Constants
    {
        internal const string BaseUrl = "https://api.notion.com/";
        internal const string DefaultNotionVersion = "2026-03-11";
        internal const string HttpClientName = "NotionClient";
    }
}
