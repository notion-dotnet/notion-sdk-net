using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

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

    [Fact]
    public async Task RetrieveTokenUser_WorkspaceInternalToken()
    {
        // Arrange
        var jsonData = await File.ReadAllTextAsync("data/users/MeResponse.json");

        var path = ApiEndpoints.UsersApiUrls.Me();

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        // Act
        var user = await _client.MeAsync();

        // Assert
        user.Id.Should().Be("590693f3-797f-4970-98ff-7284106393e5");
        user.Name.Should().Be("Test");
        user.AvatarUrl.Should().BeNull();
        user.Type.Should().Be("bot");
        user.Person.Should().BeNull();
        user.Bot.Should().NotBeNull();
        user.Bot.Owner.Should().BeOfType<WorkspaceIntegrationOwner>();

        var owner = (WorkspaceIntegrationOwner)user.Bot.Owner;
        owner.Workspace.Should().BeTrue();
    }

    [Fact]
    public async Task RetrieveTokenUser_UserLevelToken()
    {
        // Arrange
        var jsonData = await File.ReadAllTextAsync("data/users/MeUserLevelResponse.json");

        var path = ApiEndpoints.UsersApiUrls.Me();

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(jsonData)
            );

        // Act
        var user = await _client.MeAsync();

        // Assert
        user.Id.Should().Be("16d84278-ab0e-484c-9bdd-b35da3bd8905");
        user.Name.Should().Be("pied piper");
        user.AvatarUrl.Should().BeNull();
        user.Type.Should().Be("bot");
        user.Person.Should().BeNull();
        user.Bot.Should().NotBeNull();
        user.Bot.Owner.Should().BeOfType<UserOwner>();

        var owner = (UserOwner)user.Bot.Owner;
        owner.User.Id.Should().Be("5389a034-eb5c-47b5-8a9e-f79c99ef166c");
        owner.User.Name.Should().Be("christine makenotion");
        owner.User.AvatarUrl.Should().BeNull();
        owner.User.Type.Should().Be("person");
        owner.User.Person.Email.Should().Be("christine@makenotion.com");
        owner.User.Bot.Should().BeNull();
    }
}
