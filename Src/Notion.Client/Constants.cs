using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Notion.UnitTests")]
namespace Notion.Client
{
    internal class Constants
    {
        internal static string BASE_URL = "https://api.notion.com/";
        internal static string DEFAULT_NOTION_VERSION = "2022-06-28";
    }
}
