using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class NotionClientLogging
    {
        private static ILoggerFactory _factory;

        public static void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            _factory = loggerFactory;

            Log.Logger = Log.Logger == null ? _factory?.CreateLogger("Notion.Client") : Log.Logger;
        }
    }
}
