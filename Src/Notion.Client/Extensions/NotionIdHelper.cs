using System;
using System.Text.RegularExpressions;

namespace Notion.Client
{
    /// <summary>
    /// Helper utilities for extracting and normalising Notion UUIDs from URLs or raw ID strings.
    /// </summary>
    public static class NotionIdHelper
    {
        // Matches a fully-hyphenated UUID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        private static readonly Regex HyphenatedUuidRegex = new Regex(
            @"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Matches exactly 32 consecutive hex characters (compact UUID, no hyphens)
        private static readonly Regex CompactUuidRegex = new Regex(
            @"^[0-9a-f]{32}$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Extracts the last 32-hex-char segment from a URL path segment.
        // Mirrors the JS SDK pattern: /-([0-9a-f]{32})(?:[/?#]|$)/
        private static readonly Regex PathSegmentRegex = new Regex(
            @"-([0-9a-f]{32})(?:[/?#]|$)",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Fallback: any 32 consecutive hex chars anywhere in the string
        private static readonly Regex AnyCompactUuidRegex = new Regex(
            @"[0-9a-f]{32}",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Block fragment: #block-<32hex> or #<32hex>
        private static readonly Regex BlockFragmentRegex = new Regex(
            @"#(?:block-)?([0-9a-f]{32})(?:[/?#]|$)",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Formats a raw 32-character hex string into the standard
        /// <c>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</c> UUID form.
        /// </summary>
        private static string FormatUuid(string compact)
        {
            var s = compact.ToLowerInvariant();
            return $"{s.Substring(0, 8)}-{s.Substring(8, 4)}-{s.Substring(12, 4)}-{s.Substring(16, 4)}-{s.Substring(20, 12)}";
        }

        /// <summary>
        /// Extracts a Notion UUID from a URL or passes it through if it is already a UUID.
        /// </summary>
        /// <param name="urlOrId">A Notion page/database URL, a hyphenated UUID, or a compact UUID.</param>
        /// <returns>
        /// A lower-cased, hyphenated UUID string; or <see langword="null"/> if no valid ID
        /// could be found.
        /// </returns>
        public static string ExtractNotionId(string urlOrId)
        {
            if (string.IsNullOrWhiteSpace(urlOrId))
            {
                return null;
            }

            var trimmed = urlOrId.Trim();

            // 1. Already a hyphenated UUID — return as-is (lowercased)
            if (HyphenatedUuidRegex.IsMatch(trimmed))
            {
                return trimmed.ToLowerInvariant();
            }

            // 2. Compact (32 hex chars) UUID — format and return
            if (CompactUuidRegex.IsMatch(trimmed))
            {
                return FormatUuid(trimmed);
            }

            // From here on we treat the input as a URL.

            // 3. Extract from URL path: pattern /-([0-9a-f]{32})(?:[/?#]|$)/
            var pathMatch = PathSegmentRegex.Match(trimmed);
            if (pathMatch.Success)
            {
                return FormatUuid(pathMatch.Groups[1].Value);
            }

            // 4. Fallback to known query parameters
            foreach (var paramName in new[] { "p", "page_id", "database_id" })
            {
                var paramValue = GetQueryParam(trimmed, paramName);
                if (paramValue != null)
                {
                    // The query param value may itself be a compact or hyphenated UUID
                    var extracted = ExtractNotionId(paramValue);
                    if (extracted != null)
                    {
                        return extracted;
                    }
                }
            }

            // 5. Last resort: any 32 hex chars in the URL
            var anyMatch = AnyCompactUuidRegex.Match(trimmed);
            if (anyMatch.Success)
            {
                return FormatUuid(anyMatch.Value);
            }

            return null;
        }

        /// <summary>
        /// Convenience wrapper around <see cref="ExtractNotionId"/> for page URLs.
        /// </summary>
        /// <param name="pageUrl">A Notion page URL or ID.</param>
        /// <returns>A hyphenated UUID; or <see langword="null"/> if not found.</returns>
        public static string ExtractPageId(string pageUrl)
        {
            return ExtractNotionId(pageUrl);
        }

        /// <summary>
        /// Convenience wrapper around <see cref="ExtractNotionId"/> for database URLs.
        /// </summary>
        /// <param name="dbUrl">A Notion database URL or ID.</param>
        /// <returns>A hyphenated UUID; or <see langword="null"/> if not found.</returns>
        public static string ExtractDatabaseId(string dbUrl)
        {
            return ExtractNotionId(dbUrl);
        }

        /// <summary>
        /// Extracts a block ID from a URL fragment of the form
        /// <c>#block-&lt;32hex&gt;</c> or <c>#&lt;32hex&gt;</c>.
        /// </summary>
        /// <param name="urlWithBlock">A Notion URL that contains a block fragment.</param>
        /// <returns>A hyphenated UUID for the block; or <see langword="null"/> if not found.</returns>
        public static string ExtractBlockId(string urlWithBlock)
        {
            if (string.IsNullOrWhiteSpace(urlWithBlock))
            {
                return null;
            }

            var match = BlockFragmentRegex.Match(urlWithBlock.Trim());
            if (match.Success)
            {
                return FormatUuid(match.Groups[1].Value);
            }

            return null;
        }

        /// <summary>
        /// Naive query-string parameter extractor that avoids a dependency on
        /// <c>System.Web.HttpUtility</c> (not available in netstandard2.0 without an extra package).
        /// </summary>
        private static string GetQueryParam(string url, string paramName)
        {
            // Find the query string portion
            var queryStart = url.IndexOf('?');
            if (queryStart < 0)
            {
                return null;
            }

            // Strip off any fragment
            var fragmentStart = url.IndexOf('#', queryStart);
            var query = fragmentStart >= 0
                ? url.Substring(queryStart + 1, fragmentStart - queryStart - 1)
                : url.Substring(queryStart + 1);

            foreach (var part in query.Split('&'))
            {
                var eq = part.IndexOf('=');
                if (eq < 0)
                {
                    continue;
                }

                var key = Uri.UnescapeDataString(part.Substring(0, eq));
                if (string.Equals(key, paramName, StringComparison.OrdinalIgnoreCase))
                {
                    return Uri.UnescapeDataString(part.Substring(eq + 1));
                }
            }

            return null;
        }
    }
}
