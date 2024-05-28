using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabasesClient
    {
        /// <summary>
        ///     Retrieves a Database object using the ID specified.
        /// </summary>
        /// <param name="databaseId">Identifier for a Notion database</param>
        /// <returns>
        ///     <see cref="Database" />
        /// </returns>
        Task<Database> RetrieveAsync(string databaseId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets a list of Pages contained in the database, filtered and ordered according to the
        ///     filter conditions and sort criteria provided in the request. The response may contain
        ///     fewer than <c>page_size</c> of results.
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="databasesQueryParameters"></param>
        /// <returns>
        ///     <see cref="PaginatedList{T}" />
        /// </returns>
        Task<DatabaseQueryResponse> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Creates a database as a subpage in the specified parent page, with the specified properties schema.
        /// </summary>
        /// <param name="databasesCreateParameters"></param>
        /// <returns>
        ///     <see cref="Database" />
        /// </returns>
        Task<Database> CreateAsync(DatabasesCreateParameters databasesCreateParameters, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates an existing database as specified by the parameters.
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="databasesUpdateParameters"></param>
        /// <returns>
        ///     <see cref="Database" />
        /// </returns>
        Task<Database> UpdateAsync(string databaseId, DatabasesUpdateParameters databasesUpdateParameters, CancellationToken cancellationToken = default);
    }
}
