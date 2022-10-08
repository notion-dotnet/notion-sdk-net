using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Notion.UnitTests")]

namespace Notion.Client
{
    internal static class Constants
    {
        internal const string BaseUrl = "https://api.notion.com/";
        internal const string DefaultNotionVersion = "2022-06-28";
    }
}
