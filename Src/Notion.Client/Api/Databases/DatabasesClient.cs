using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class DatabasesClient : IDatabasesClient
    {
        private readonly IRestClient _client;

        public DatabasesClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<Database> RetrieveAsync(string databaseId)
        {
            return await _client.GetAsync<Database>(DatabasesApiUrls.Retrieve(databaseId));
        }

        public async Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null)
        {
            var databasesListQueryParmaters = (IDatabasesListQueryParmaters)databasesListParameters;

            var queryParams = new Dictionary<string, string>()
            {
                { "start_cursor", databasesListQueryParmaters?.StartCursor },
                { "page_size", databasesListQueryParmaters?.PageSize }
            };

            return await _client.GetAsync<PaginatedList<Database>>(DatabasesApiUrls.List(), queryParams);
        }

        public async Task<PaginatedList<Page>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters)
        {
            var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;

            return await _client.PostAsync<PaginatedList<Page>>(DatabasesApiUrls.Query(databaseId), body);
        }
        
        public async Task QueryToEndAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters, Action<List<Page>> onPartReceived)
        {
            databasesQueryParameters = databasesQueryParameters.CreateCopy();
            List<List<Page>> results = new List<List<Page>>(1);
            
            while(true)
            {
                var paginatedList = await QueryAsync(databaseId, databasesQueryParameters);
                results.Add(paginatedList.Results);
                
                if (!paginatedList.HasMore) break;
                
                onPartReceived.Invoke(paginatedList.Results);
                databasesQueryParameters.StartCursor = paginatedList.NextCursor;
            }
        }
    }
}