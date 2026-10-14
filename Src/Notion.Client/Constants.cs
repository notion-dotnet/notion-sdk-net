using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Notion.UnitTests")]

namespace Notion.Client
{
    internal static class Constants
    {
        internal const string BaseUrl = "https://api.notion.com/";
        internal const string DefaultNotionVersion = "2026-03-11";
        internal const string HttpClientName = "NotionClient";

        internal static readonly string UserAgent = "notion-sdk-net/" + GetVersion();

        private static string GetVersion()
        {
            var assembly = typeof(Constants).Assembly;
            var version = (System.Attribute.GetCustomAttribute(assembly, typeof(System.Reflection.AssemblyInformationalVersionAttribute))
                as System.Reflection.AssemblyInformationalVersionAttribute)?.InformationalVersion
                ?? assembly.GetName().Version?.ToString()
                ?? "unknown";

            // Drop build metadata such as "+<commit sha>".
            var plus = version.IndexOf('+');

            return plus >= 0 ? version.Substring(0, plus) : version;
        }
    }
}
