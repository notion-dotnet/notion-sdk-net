using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// Helpers for reading whole data sources and template lists.
    /// </summary>
    public static class NotionDataSourceHelpers
    {
        /// <summary>
        /// Lazily yields every row of a data source, including rows past the per-query result limit.
        /// <para>
        /// A single query returns at most a fixed number of rows in total; when that limit is hit the response has
        /// <see cref="QueryDataSourceRequestStatus.IsIncomplete" /> set. This helper then continues with a new query
        /// restricted to rows created at or after the last row seen (sorted by <c>created_time</c> ascending), and
        /// de-duplicates rows by id, so the whole data source is covered.
        /// </para>
        /// <para>
        /// <see cref="QueryDataSourceRequest.Sorts" /> and <see cref="QueryDataSourceRequest.StartCursor" /> are
        /// managed by the helper and ignored; <see cref="QueryDataSourceRequest.Filter" /> is combined with the
        /// <c>created_time</c> bound. The request object itself is not modified.
        /// </para>
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// More rows share one <c>created_time</c> than the query limit allows, so the window cannot advance. Add a
        /// filter to narrow the query.
        /// </exception>
        public static async IAsyncEnumerable<IQueryDataSourceResponseObject> IterateAllDataSourceRowsAsync(
            IDataSourcesClient client,
            QueryDataSourceRequest request,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var seenRowIds = new HashSet<string>();
            DateTime? windowStart = null;

            while (true)
            {
                var limitReached = false;
                DateTime? lastCreatedTime = null;
                string cursor = null;

                do
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var response = await client
                        .QueryAsync(CreateWindowRequest(request, windowStart, cursor), cancellationToken)
                        .ConfigureAwait(false);

                    foreach (var row in response.Results)
                    {
                        // Wiki data sources can return child data sources next to pages. Both carry created_time and
                        // either can be the boundary row, so advance on either.
                        var createdTime = GetCreatedTime(row);

                        if (createdTime != null)
                        {
                            lastCreatedTime = createdTime;
                        }

                        if (seenRowIds.Add(row.Id))
                        {
                            yield return row;
                        }
                    }

                    if (response.RequestStatus != null && response.RequestStatus.IsIncomplete)
                    {
                        limitReached = true;
                    }

                    cursor = response.HasMore && !string.IsNullOrEmpty(response.NextCursor)
                        ? response.NextCursor
                        : null;
                }
                while (cursor != null);

                if (!limitReached)
                {
                    yield break;
                }

                if (lastCreatedTime == null || lastCreatedTime == windowStart)
                {
                    throw new InvalidOperationException(
                        "IterateAllDataSourceRowsAsync cannot make progress: the per-query result limit was reached "
                        + "but the created_time window could not advance past "
                        + $"{(lastCreatedTime?.ToString("o") ?? "(no rows)")}. More rows share this timestamp than "
                        + "the limit allows. Add a filter to narrow the query.");
                }

                windowStart = lastCreatedTime;
            }
        }

        /// <summary>
        /// Collects every row of a data source into a list, including rows past the per-query result limit.
        /// See <see cref="IterateAllDataSourceRowsAsync" /> for how the limit is handled. Make sure the whole data
        /// source fits in memory; otherwise iterate and process the rows as they stream.
        /// </summary>
        public static async Task<List<IQueryDataSourceResponseObject>> CollectAllDataSourceRowsAsync(
            IDataSourcesClient client,
            QueryDataSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            var rows = new List<IQueryDataSourceResponseObject>();

            await foreach (var row in IterateAllDataSourceRowsAsync(client, request, cancellationToken)
                               .ConfigureAwait(false))
            {
                rows.Add(row);
            }

            return rows;
        }

        /// <summary>
        /// Lazily yields every template of a data source across all pages.
        /// <see cref="ListDataSourceTemplatesRequest.StartCursor" /> is managed by the helper and ignored.
        /// </summary>
        public static async IAsyncEnumerable<DataSourceTemplate> IterateDataSourceTemplatesAsync(
            IDataSourcesClient client,
            ListDataSourceTemplatesRequest request,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string cursor = null;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var response = await client.ListDataSourceTemplatesAsync(
                    new ListDataSourceTemplatesRequest
                    {
                        DataSourceId = request.DataSourceId,
                        Name = request.Name,
                        PageSize = request.PageSize,
                        StartCursor = cursor
                    },
                    cancellationToken).ConfigureAwait(false);

                if (response.Templates != null)
                {
                    foreach (var template in response.Templates)
                    {
                        yield return template;
                    }
                }

                if (!response.HasMore || string.IsNullOrEmpty(response.NextCursor))
                {
                    yield break;
                }

                cursor = response.NextCursor;
            }
        }

        /// <summary>
        /// Collects every template of a data source into a list.
        /// </summary>
        public static async Task<List<DataSourceTemplate>> CollectDataSourceTemplatesAsync(
            IDataSourcesClient client,
            ListDataSourceTemplatesRequest request,
            CancellationToken cancellationToken = default)
        {
            var templates = new List<DataSourceTemplate>();

            await foreach (var template in IterateDataSourceTemplatesAsync(client, request, cancellationToken)
                               .ConfigureAwait(false))
            {
                templates.Add(template);
            }

            return templates;
        }

        private static DateTime? GetCreatedTime(IQueryDataSourceResponseObject row)
        {
            switch (row)
            {
                case Page page when NotionTypeGuards.IsFullPage(page):
                    return page.CreatedTime;
                case DataSource dataSource when NotionTypeGuards.IsFullDataSource(dataSource):
                    return dataSource.CreatedTime;
                default:
                    return null;
            }
        }

        private static QueryDataSourceRequest CreateWindowRequest(
            QueryDataSourceRequest source,
            DateTime? windowStart,
            string cursor)
        {
#pragma warning disable CS0618
            return new QueryDataSourceRequest
            {
                DataSourceId = source.DataSourceId,
                FilterProperties = source.FilterProperties,
                PageSize = source.PageSize,
                InTrash = source.InTrash,
                Archived = source.Archived,
                ResultType = source.ResultType,
                Sorts = new[] { new Sort { Timestamp = Timestamp.CreatedTime, Direction = Direction.Ascending } },
                Filter = CreatedTimeLowerBound(source.Filter, windowStart),
                StartCursor = cursor
            };
#pragma warning restore CS0618
        }

        /// <summary>
        /// Combines the caller's filter with the created_time lower bound that advances the window. The filter is
        /// returned unchanged for the first window, which has no bound yet.
        /// </summary>
        private static Filter CreatedTimeLowerBound(Filter filter, DateTime? windowStart)
        {
            if (windowStart == null)
            {
                return filter;
            }

            var bound = new TimestampCreatedTimeFilter(onOrAfter: windowStart);

            if (filter == null)
            {
                return bound;
            }

            if (filter is CompoundFilter compound && compound.And != null && compound.Or == null)
            {
                return new CompoundFilter(and: new List<Filter>(compound.And) { bound });
            }

            return new CompoundFilter(and: new List<Filter> { filter, bound });
        }
    }
}
