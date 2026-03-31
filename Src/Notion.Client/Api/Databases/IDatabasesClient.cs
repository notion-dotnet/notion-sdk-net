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
        ///     Creates a database as a subpage in the specified parent page, with the specified properties schema.
        /// </summary>
        /// <param name="databasesCreateParameters"></param>
        /// <returns>
        ///     <see cref="Database" />
        /// </returns>
        Task<Database> CreateAsync(DatabasesCreateRequest databasesCreateParameters, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates an existing database as specified by the parameters.
        /// </summary>
        /// <param name="databasesUpdateRequest"></param>
        /// <returns>
        ///     <see cref="Database" />
        /// </returns>
        Task<Database> UpdateAsync(DatabasesUpdateRequest databasesUpdateRequest, CancellationToken cancellationToken = default);
    }
}
