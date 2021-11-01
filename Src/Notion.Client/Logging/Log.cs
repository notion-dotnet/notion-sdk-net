using System;
using Microsoft.Extensions.Logging;

namespace Notion.Client
{
    internal static class Log
    {
        internal static ILogger logger;

        internal static void Trace(string message, params object[] args)
        {
            logger?.LogTrace(message, args);
        }

        internal static void Information(string message, params object[] args)
        {
            logger?.LogInformation(message, args);
        }

        internal static void Error(Exception ex, string message, params object[] args)
        {
            logger?.LogError(ex, message, args);
        }
    }
}
