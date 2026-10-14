using System;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class ErrorHandlingTests : IntegrationTestBase
{
    [Fact]
    public async Task NotFound_Error_Exposes_Request_Details()
    {
        var act = () => Client.Pages.RetrieveAsync(Guid.NewGuid().ToString());

        var exception = (await act.Should().ThrowAsync<NotionApiException>()).Which;

        exception.NotionAPIErrorCode.Should().Be(NotionAPIErrorCode.ObjectNotFound);
        exception.Message.Should().NotBeNullOrEmpty();
        exception.RequestId.Should().NotBeNullOrEmpty();
        exception.ResponseBody.Should().Contain("object_not_found");
        exception.ResponseHeaders.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Unauthorized_Error_Has_Code_And_Request_Id()
    {
        var client = NotionClientFactory.Create(new ClientOptions { AuthToken = "invalid-token" });

        var act = () => client.Users.MeAsync();

        var exception = (await act.Should().ThrowAsync<NotionApiException>()).Which;

        exception.NotionAPIErrorCode.Should().Be(NotionAPIErrorCode.Unauthorized);
        exception.RequestId.Should().NotBeNullOrEmpty();
    }
}
