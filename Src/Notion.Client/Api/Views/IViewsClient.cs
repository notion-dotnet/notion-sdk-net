using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IViewsClient
    {
        /// <summary>
        /// Lists views for a database or data source.
        /// </summary>
        Task<PaginatedList<View>> ListAsync(
            ListViewsRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new view.
        /// </summary>
        Task<View> CreateAsync(
            CreateViewRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a view by its ID.
        /// </summary>
        Task<View> RetrieveAsync(
            string viewId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing view.
        /// </summary>
        Task<View> UpdateAsync(
            UpdateViewRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a view by its ID.
        /// </summary>
        Task<View> DeleteAsync(
            string viewId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a query against a view.
        /// </summary>
        Task<ViewQueryResponse> CreateQueryAsync(
            CreateViewQueryRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the results of a previously created view query.
        /// </summary>
        Task<PaginatedList<PageReference>> GetQueryResultsAsync(
            GetViewQueryResultsRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a view query.
        /// </summary>
        Task<DeletedViewQueryResponse> DeleteQueryAsync(
            DeleteViewQueryRequest request,
            CancellationToken cancellationToken = default);
    }
}
