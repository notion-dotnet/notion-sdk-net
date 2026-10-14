using System;

namespace Notion.Client
{
    /// <summary>
    /// Thrown when a request path contains a path-traversal sequence (<c>..</c> or <c>%2e%2e</c>),
    /// e.g. from an untrusted id that was interpolated into a URL.
    /// </summary>
    public sealed class InvalidPathParameterException : ArgumentException
    {
        public InvalidPathParameterException(string path)
            : base($"The request path contains an invalid path segment: '{path}'.", nameof(path))
        {
        }
    }
}
