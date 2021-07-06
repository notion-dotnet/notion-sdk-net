using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabasesClient
    {
        Task<Database> RetrieveAsync(string databaseId);
        Task<PaginatedList<Page>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters);
        Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null);

        Task QueryToEndAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters,
            Action<List<Page>> onPartReceived);
    }
}
