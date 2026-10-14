using System;

namespace Notion.Client
{
    /// <summary>
    /// Thrown when a request exceeds <see cref="ClientOptions.Timeout" />. A cancellation requested by the
    /// caller through a <see cref="System.Threading.CancellationToken" /> still surfaces as the usual
    /// <see cref="OperationCanceledException" />.
    /// </summary>
    public sealed class NotionRequestTimeoutException : TimeoutException
    {
        public NotionRequestTimeoutException(TimeSpan timeout)
            : base($"Request to the Notion API timed out after {(int)timeout.TotalMilliseconds}ms.")
        {
            Timeout = timeout;
        }

        public TimeSpan Timeout { get; }
    }
}
