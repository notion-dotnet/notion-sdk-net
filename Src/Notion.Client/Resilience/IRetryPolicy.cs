using System;
using System.Net.Http;

namespace Notion.Client
{
    /// <summary>
    /// Defines whether and how long to wait before retrying a failed HTTP request.
    /// </summary>
    /// <remarks>
    /// Implement this interface to plug in a custom retry strategy (e.g. Polly).
    /// The built-in implementation is <see cref="DefaultRetryPolicy"/>.
    /// </remarks>
    public interface IRetryPolicy
    {
        /// <summary>
        /// Returns <c>true</c> if the request should be retried after the given response.
        /// </summary>
        /// <param name="response">The HTTP response received.</param>
        /// <param name="method">The HTTP method of the original request.</param>
        /// <param name="attempt">Zero-based attempt index (0 = first failure).</param>
        bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt);

        /// <summary>
        /// Returns how long to wait before the next attempt.
        /// Called only when <see cref="ShouldRetry"/> returned <c>true</c>.
        /// </summary>
        /// <param name="response">The HTTP response received.</param>
        /// <param name="attempt">Zero-based attempt index (0 = first failure).</param>
        TimeSpan GetDelay(HttpResponseMessage response, int attempt);
    }
}
