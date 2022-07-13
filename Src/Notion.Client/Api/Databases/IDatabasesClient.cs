using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabasesClient
    {
        Task<Database> RetrieveAsync(string databaseId);
        Task<PaginatedList<Page>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters);

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
