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
    }

    public class DatabasesClient : IDatabasesClient
    {
        private readonly IRestClient _client;

        public DatabasesClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<Database> RetrieveAsync(string databaseId)
        {
            try
            {
                return await _client.GetAsync<Database>($"/v1/databases/{databaseId}");
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
                var databasesListQueryParmaters = (IDatabasesListQueryParmaters)databasesListParameters;
                var queryParams = new Dictionary<string, string>()
                {
                    { "start_cursor", databasesListQueryParmaters?.StartCursor },
                    { "page_size", databasesListQueryParmaters?.PageSize }
                };

                return await _client.GetAsync<PaginatedList<Database>>("/v1/databases", queryParams);
            }
            catch (Exception e)
            {
                // Todo: Throw Custom Exception
                return null;
            }
        }

        public async Task<PaginatedList<Page>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters)
        {
            try
            {
                var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;
                return await _client.PostAsync<PaginatedList<Page>>($"/v1/databases/{databaseId}/query", body);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}