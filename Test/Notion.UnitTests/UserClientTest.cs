using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.UnitTests
{
    public class UserClientTest
    {
        private readonly IUsersClient _client;

        public UserClientTest()
        {
            var options = new ClientOptions
            {
                AuthToken = "<Token>"
            };

            _client = new UsersClient(new RestClient(options));
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
