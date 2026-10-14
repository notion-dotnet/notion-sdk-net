using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class GenericRequestTests : IntegrationTestBase
{
    [Fact]
    public async Task RequestAsync_Get_ReturnsRawJson()
    {
        var me = await Client.RequestAsync<JObject>(HttpMethod.Get, "/v1/users/me");

        me["object"]!.Value<string>().Should().Be("user");
        me["id"]!.Value<string>().Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task RequestAsync_Post_WithJsonBody_ReturnsResults()
    {
        var result = await Client.RequestAsync<JObject>(
            HttpMethod.Post,
            "/v1/search",
            JObject.Parse("{\"page_size\": 1}"));

        result["object"]!.Value<string>().Should().Be("list");
        result["results"].Should().BeOfType<JArray>();
    }

    [Fact]
    public async Task RequestAsync_WithAuthTokenOverride_UsesTheOverride()
    {
        var act = () => Client.RequestAsync<JObject>(
            HttpMethod.Get,
            "/v1/users/me",
            options: new ClientRequestOptions { AuthToken = "invalid-token" });

        var exception = (await act.Should().ThrowAsync<NotionApiException>()).Which;
        exception.NotionAPIErrorCode.Should().Be(NotionAPIErrorCode.Unauthorized);
    }

    [Fact]
    public async Task RequestAsync_WithNotionVersionHeader_UsesTheOverride()
    {
        var me = await Client.RequestAsync<JObject>(
            HttpMethod.Get,
            "/v1/users/me",
            options: new ClientRequestOptions
            {
                Headers = new Dictionary<string, string> { { "Notion-Version", "2022-06-28" } }
            });

        me["object"]!.Value<string>().Should().Be("user");
    }
}
