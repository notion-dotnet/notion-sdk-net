using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;

namespace Notion.Client.http
{
    internal static class QueryHelpers
    {
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static string AddQueryString(string uri, string name, string value)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return AddQueryString(uri, new[] { new KeyValuePair<string, string>(name, value) });
        }

        public static string AddQueryString(string uri, IDictionary<string, string> queryParams)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryParams == null)
            {
                throw new ArgumentNullException(nameof(queryParams));
            }

            return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string>>)queryParams);
        }

        public static string AddQueryString(
            string uri,
            IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryParams == null)
            {
                throw new ArgumentNullException(nameof(queryParams));
            }

            queryParams = RemoveEmptyValueQueryParams(queryParams);

            var anchorIndex = uri.IndexOf('#');
            var uriToBeAppended = uri;
            var anchorText = "";

            if (anchorIndex != -1)
            {
                anchorText = uri.Substring(anchorIndex);
                uriToBeAppended = uri.Substring(0, anchorIndex);
            }

            var queryIndex = uriToBeAppended.IndexOf('?');
            var hasQuery = queryIndex != -1;

            var sb = new StringBuilder();
            sb.Append(uriToBeAppended);

            foreach (var parameter in queryParams)
            {
                sb.Append(hasQuery ? '&' : '?');
                sb.Append(WebUtility.UrlEncode(parameter.Key));
                sb.Append('=');
                sb.Append(WebUtility.UrlEncode(parameter.Value));
                hasQuery = true;
            }

            sb.Append(anchorText);

            return sb.ToString();
        }

        private static IEnumerable<KeyValuePair<string, string>> RemoveEmptyValueQueryParams(
            IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            return queryParams.Where(x => !string.IsNullOrWhiteSpace(x.Value));
        }
    }
}
