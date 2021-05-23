using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabaseClient
    {
        Task<Database> RetrieveAsync(string databaseId);
        Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null);
    }

    public class DatabaseClient : IDatabaseClient
    {
        private readonly IRestClient _client;

        public DatabaseClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<Database> RetrieveAsync(string databaseId)
        {
            try
            {
                return await _client.GetAsync<Database>($"databases/{databaseId}");
            }
            catch (Exception e)
            {
                // Todo: Throw Custom Exception
                return null;
            }
        }

        public async Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null)
        {
            try
            {
                var queryParams = new Dictionary<string, string>()
                {
                    { "start_cursor", databasesListParameters?.PaginationParameters?.StartCursor },
                    { "page_size", databasesListParameters?.PaginationParameters?.PageSize }
                };

                return await _client.GetAsync<PaginatedList<Database>>("databases", queryParams);
            }
            catch (Exception e)
            {
                // Todo: Throw Custom Exception
                return null;
            }
        }
    }
}