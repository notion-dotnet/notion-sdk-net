using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> that retries failed requests according to an <see cref="IRetryPolicy"/>.
    /// <para>
    /// The library applies retry logic internally via <see cref="ClientOptions.RetryPolicy"/> —
    /// use this handler only when you need to embed retry behaviour directly in an <see cref="HttpClient"/>
    /// pipeline outside of the standard <c>NotionClientFactory</c> / DI setup.
    /// </para>
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {
        private readonly IRetryPolicy _policy;

        /// <param name="policy">The retry policy that decides whether and how long to retry.</param>
        public RetryHandler(IRetryPolicy policy)
        {
            _policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            for (var attempt = 0; ; attempt++)
            {
                var response = await base.SendAsync(request, cancellationToken);

                if (!_policy.ShouldRetry(response, request.Method, attempt))
                {
                    return response;
                }

                var delay = _policy.GetDelay(response, attempt);

                Log.Trace(
                    "Retry attempt {attempt} after {delay}ms (HTTP {status})",
                    attempt + 1,
                    (int)delay.TotalMilliseconds,
                    (int)response.StatusCode);

                response.Dispose();

                await Task.Delay(delay, cancellationToken);
            }
        }
    }
}
