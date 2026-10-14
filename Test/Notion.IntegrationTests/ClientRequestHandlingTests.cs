using System;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

/// <summary>
/// Timeout and path validation of the client against the real Notion API.
/// </summary>
public class ClientRequestHandlingTests : IntegrationTestBase
{
    private static INotionClient CreateClient(TimeSpan? timeout = null) =>
        NotionClientFactory.Create(new ClientOptions
        {
            AuthToken = GetEnvironmentVariableRequired("NOTION_AUTH_TOKEN"), Timeout = timeout
        });

    [Fact]
    public async Task Request_Exceeding_Timeout_Throws_NotionRequestTimeoutException()
    {
        var client = CreateClient(TimeSpan.FromMilliseconds(1));

        var act = () => client.Users.MeAsync();

        var exception = (await act.Should().ThrowAsync<NotionRequestTimeoutException>()).Which;
        exception.Timeout.Should().Be(TimeSpan.FromMilliseconds(1));
    }

    [Fact]
    public async Task Request_Within_Timeout_Succeeds()
    {
        var client = CreateClient(TimeSpan.FromSeconds(60));

        var me = await client.Users.MeAsync();

        me.Id.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("../users/me")]
    [InlineData("abc/../../users/me")]
    [InlineData("%2e%2e/users/me")]
    [InlineData("%2E%2E")]
    public async Task Path_Traversal_In_An_Id_Is_Rejected_Before_Sending(string id)
    {
        var act = () => Client.Pages.RetrieveAsync(id);

        await act.Should().ThrowAsync<InvalidPathParameterException>();
    }
}
