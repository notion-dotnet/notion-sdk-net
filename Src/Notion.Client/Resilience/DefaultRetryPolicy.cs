using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Notion.Client
{
    /// <summary>
    /// The built-in retry policy with exponential backoff and jitter.
    /// <list type="bullet">
    ///   <item><description>HTTP 429 (rate limited) — retried for all HTTP methods.</description></item>
    ///   <item><description>HTTP 529 (service overload) — retried for all HTTP methods.</description></item>
    ///   <item><description>HTTP 500 (internal server error) — retried only for idempotent methods (GET, DELETE).</description></item>
    ///   <item><description>HTTP 503 (service unavailable) — retried only for idempotent methods (GET, DELETE).</description></item>
    /// </list>
    /// A <c>Retry-After</c> header on a retried response (seconds or an HTTP date) is honoured, capped at <see cref="MaxDelay"/>.
    /// Subclass and override <see cref="ShouldRetry"/> or <see cref="GetDelay"/> to customise individual aspects
    /// while reusing the rest of the default behaviour.
    /// </summary>
    public class DefaultRetryPolicy : IRetryPolicy
    {
        private static readonly ISet<HttpMethod> IdempotentMethods = new HashSet<HttpMethod>
        {
            HttpMethod.Get,
            HttpMethod.Delete
        };

        // Random is not thread-safe, but ThreadLocal avoids locking overhead.
        private static readonly ThreadLocal<Random> Rng =
            new ThreadLocal<Random>(() => new Random());

        /// <summary>Maximum number of retry attempts. Defaults to 3.</summary>
        public int MaxRetries { get; }

        /// <summary>Delay before the first retry. Doubles on each subsequent attempt. Defaults to 1 second.</summary>
        public TimeSpan InitialDelay { get; }

        /// <summary>Upper bound on the computed delay (before jitter). Defaults to 60 seconds.</summary>
        public TimeSpan MaxDelay { get; }

        /// <param name="maxRetries">Maximum number of retry attempts (default 3).</param>
        /// <param name="initialDelay">Delay before first retry; doubles each attempt (default 1 s).</param>
        /// <param name="maxDelay">Upper bound on delay before jitter is applied (default 60 s).</param>
        public DefaultRetryPolicy(
            int maxRetries = 3,
            TimeSpan? initialDelay = null,
            TimeSpan? maxDelay = null)
        {
            MaxRetries = maxRetries;
            InitialDelay = initialDelay ?? TimeSpan.FromSeconds(1);
            MaxDelay = maxDelay ?? TimeSpan.FromSeconds(60);
        }

        /// <inheritdoc/>
        public virtual bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
        {
            if (attempt >= MaxRetries)
            {
                return false;
            }

            return (int)response.StatusCode switch
            {
                429 or 529 => true,
                500 or 503 => IdempotentMethods.Contains(method),
                _ => false
            };
        }

        /// <inheritdoc/>
        public virtual TimeSpan GetDelay(HttpResponseMessage response, int attempt)
        {
            // Honour the Retry-After header (delta seconds or HTTP date), capped at MaxDelay.
            var retryAfter = response.Headers.RetryAfter;
            var serverDelay = retryAfter?.Delta
                ?? (retryAfter?.Date is { } date ? date - DateTimeOffset.UtcNow : (TimeSpan?)null);

            if (serverDelay is { } fromServer)
            {
                if (fromServer < TimeSpan.Zero)
                {
                    fromServer = TimeSpan.Zero;
                }

                return fromServer > MaxDelay ? MaxDelay : fromServer;
            }

            // Exponential backoff: initialDelay * 2^attempt, capped at MaxDelay, plus random jitter.
            var exponential = TimeSpan.FromMilliseconds(
                InitialDelay.TotalMilliseconds * Math.Pow(2, attempt));

            var capped = exponential > MaxDelay ? MaxDelay : exponential;

            var jitter = TimeSpan.FromMilliseconds(Rng.Value.Next(0, 1000));

            return capped + jitter;
        }
    }
}
