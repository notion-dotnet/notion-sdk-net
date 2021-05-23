using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabaseClient
    {
        Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null);
    }

    public class DatabaseClient : IDatabaseClient
    {
        private readonly IRestClient _client;

        public DatabaseClient(IRestClient client)
        {
            _client = client;
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
            catch (System.Exception e)
            {
                // Todo: Throw Custom Exception
                return null;
            }
        }
    }
}