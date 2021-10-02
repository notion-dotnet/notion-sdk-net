using System;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabasesClient
    {
        Task<Database> RetrieveAsync(string databaseId);
        Task<PaginatedList<Page>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters);

        /// <summary>
        /// List all Databases shared with the authenticated integration.
        /// </summary>
        /// <param name="databasesListParameters">database list request parameters.</param>
        /// <returns>PaginatedList of databases.</returns>
        [Obsolete("This endpoint is no longer recommended, use Search instead. This endpoint will only return explicitly shared pages, while search will also return child pages within explicitly shared pages. This endpoint's results cannot be filtered, while search can be used to match on page title.", false)]
        Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null);

        /// <summary>
        /// Creates a database as a subpage in the specified parent page, with the specified properties schema.
        /// </summary>
        /// <param name="databasesCreateParameters"></param>
        /// <returns>Database</returns>
        Task<Database> CreateAsync(DatabasesCreateParameters databasesCreateParameters);

        /// <summary>
        /// Updates an existing database as specified by the parameters.
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="databasesUpdateParameters"></param>
        /// <returns>Database</returns>
        Task<Database> UpdateAsync(string databaseId, DatabasesUpdateParameters databasesUpdateParameters);
    }
}
