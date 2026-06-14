using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> that retries failed requests according to an <see cref="IRetryPolicy"/>.
    /// Add this to the <see cref="HttpClient"/> pipeline when constructing the client manually,
    /// or pass a <see cref="IRetryPolicy"/> via <see cref="ClientOptions.RetryPolicy"/> to have it
    /// inserted automatically.
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
