using System;
using System.Net.Http;

namespace Notion.Client
{
    /// <summary>
    /// A retry policy that never retries. Assign <see cref="Instance"/> to <see cref="ClientOptions.RetryPolicy"/>
    /// to turn off the built-in retries, for example when retries are already handled by Polly on the supplied
    /// <see cref="HttpClient"/>.
    /// </summary>
    public sealed class NoRetryPolicy : IRetryPolicy
    {
        public static readonly NoRetryPolicy Instance = new NoRetryPolicy();

        private NoRetryPolicy()
        {
        }

        /// <inheritdoc/>
        public bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
        {
            return false;
        }

        /// <inheritdoc/>
        public TimeSpan GetDelay(HttpResponseMessage response, int attempt)
        {
            return TimeSpan.Zero;
        }
    }
}
