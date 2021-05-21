using Notion.Client;
using System.Threading.Tasks;
using Xunit;

namespace Notion.UnitTests
{
    public class UserClientTest
    {
        private readonly string _authToken;

        public UserClientTest()
        {
            _authToken = "<Token>";
        }

        [Fact(Skip = "Internal testing purpose")]
        public async Task ListUsers()
        {
            var restClient = new RestClient(_authToken);
            var client = new UsersClient(restClient);
            var usersList = await client.ListAsync();

        }
    }
}
