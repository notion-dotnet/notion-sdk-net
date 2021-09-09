using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests
{
    public class UserClientTest : ApiTestBase
    {
        private readonly IUsersClient _client;

        public UserClientTest()
        {
            _client = new UsersClient(new RestClient(ClientOptions));
        }

        [Fact]
        public async Task ListUsers()
        {
            // Arrange
            var jsonData = await File.ReadAllTextAsync("data/users/ListUsersResponse.json");
            var path = ApiEndpoints.UsersApiUrls.List();

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            // Act
            var users = await _client.ListAsync();

            // Assert
            users.Results.Should().SatisfyRespectively(
                user =>
                {
                    user.Id.Should().Be("5e37c1b4-630f-4e81-bd6b-296af31e345f");
                    user.Name.Should().Be("Vedant Koditkar");
                    user.Type.Should().Be("person");
                    user.Person.Email.Should().Be("vedkoditkar@gmail.com");
                    user.Bot.Should().BeNull();
                },
                user =>
                {
                    user.Id.Should().Be("590693f3-797f-4970-98ff-7284106393e5");
                    user.Name.Should().Be("Test");
                    user.Type.Should().Be("bot");
                    user.Person.Should().BeNull();
                }
            );
        }

        [Fact]
        public async Task RetrieveUser()
        {
            // Arrange
            var jsonData = await File.ReadAllTextAsync("data/users/RetrieveUserResponse.json");
            var userId = "5e37c1b4-630f-4e81-bd6b-296af31e345f";
            var path = ApiEndpoints.UsersApiUrls.Retrieve(userId);

            Server.Given(CreateGetRequestBuilder(path))
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

            // Act
            var user = await _client.RetrieveAsync(userId);

            // Assert
            user.Id.Should().Be("5e37c1b4-630f-4e81-bd6b-296af31e345f");
            user.Name.Should().Be("Vedant Koditkar");
            user.Type.Should().Be("person");
            user.Person.Email.Should().Be("vedkoditkar@gmail.com");
            user.Bot.Should().BeNull();
        }
    }
}
