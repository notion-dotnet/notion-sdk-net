using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// Helper utilities for consuming Notion paginated list endpoints.
    /// </summary>
    public static class NotionPaginationHelper
    {
        /// <summary>
        /// Lazily yields every item across all pages returned by <paramref name="listFn"/>, fetching the next
        /// page only when the previous one has been consumed.
        /// </summary>
        /// <typeparam name="T">The item type contained in each page.</typeparam>
        /// <param name="listFn">
        /// A delegate that accepts a <c>start_cursor</c> value (<see langword="null"/> for the
        /// first page) and returns the corresponding <see cref="PaginatedList{T}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A token that can be used to cancel the iteration before all pages are fetched.
        /// </param>
        public static async IAsyncEnumerable<T> IteratePaginatedAsync<T>(
            Func<string, Task<PaginatedList<T>>> listFn,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (listFn == null)
            {
                throw new ArgumentNullException(nameof(listFn));
            }

            string cursor = null;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var page = await listFn(cursor).ConfigureAwait(false);

                if (page?.Results != null)
                {
                    foreach (var item in page.Results)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        yield return item;
                    }
                }

                if (page == null || !page.HasMore || string.IsNullOrEmpty(page.NextCursor))
                {
                    yield break;
                }

                cursor = page.NextCursor;
            }
        }

        /// <summary>
        /// Iterates through every page returned by <paramref name="listFn"/> and
        /// collects all results into a single <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The item type contained in each page.</typeparam>
        /// <param name="listFn">
        /// A delegate that accepts a <c>start_cursor</c> value (<see langword="null"/> for the
        /// first page) and returns the corresponding <see cref="PaginatedList{T}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A token that can be used to cancel the operation before all pages are fetched.
        /// </param>
        /// <returns>A list containing every item across all pages.</returns>
        public static async Task<List<T>> CollectPaginatedAsync<T>(
            Func<string, Task<PaginatedList<T>>> listFn,
            CancellationToken cancellationToken = default)
        {
            var results = new List<T>();

            await foreach (var item in IteratePaginatedAsync(listFn, cancellationToken).ConfigureAwait(false))
            {
                results.Add(item);
            }

            return results;
        }
    }
}
