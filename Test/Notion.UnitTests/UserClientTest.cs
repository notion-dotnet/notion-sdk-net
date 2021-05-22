using Notion.Client;
using System.Threading.Tasks;
using Xunit;

namespace Notion.UnitTests
{
    public class UserClientTest
    {
        private readonly string _authToken;
        private readonly IUsersClient _client;

        public UserClientTest()
        {
            _authToken = "<Token>";
            _client = new UsersClient(new RestClient(_authToken));
        }

        [Fact(Skip = "Internal testing purpose")]
        public async Task ListUsers()
        {
            var usersList = await _client.ListAsync();
            Assert.NotNull(usersList);
        }

        [Fact(Skip = "Internal testing purpose")]
        public async Task RetrieveUser()
        {
            string userId = "5e37c1b4-630f-4e81-bd6b-296af31e345f";
            var user = await _client.RetrieveAsync(userId);
            Assert.NotNull(user);
        }
    }
}
