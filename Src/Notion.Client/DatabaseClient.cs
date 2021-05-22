using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IDatabaseClient
    {
        Task<PaginatedList<Database>> ListAsync();

    }

    public class DatabaseClient : IDatabaseClient
    {
        private readonly IRestClient _client;

        public DatabaseClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<PaginatedList<Database>> ListAsync()
        {
            try
            {
                return await _client.GetAsync<PaginatedList<Database>>("databases");
            }
            catch (System.Exception e)
            {
                // Todo: Throw Custom Exception
                return null;
            }
        }
    }
}