using Microsoft.Extensions.Logging;

namespace Notion.Client
{
    public static class NotionClientLogging
    {
        internal static ILoggerFactory factory;

        public static void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            factory = loggerFactory;

            Log.logger = Log.logger == null ? factory?.CreateLogger("Notion.Client") : Log.logger;
        }
    }
}
