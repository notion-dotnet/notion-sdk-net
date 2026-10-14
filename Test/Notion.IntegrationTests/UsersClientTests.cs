using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Notion.IntegrationTests;

public class UsersClientTests : IntegrationTestBase
{
    [Fact]
    public async Task Me_Returns_Bot_With_Workspace_Details()
    {
        var me = await Client.Users.MeAsync();

        me.Type.Should().Be("bot");
        me.Bot.Should().NotBeNull();
        me.Bot.WorkspaceId.Should().NotBeNullOrEmpty();
        me.Bot.WorkspaceLimits.Should().NotBeNull();
        me.Bot.WorkspaceLimits.MaxFileUploadSizeInBytes.Should().BeGreaterThan(0);
    }
}
