using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

/// <summary>
/// Verifies that the HttpClient lifecycle options introduced in ClientOptions work
/// correctly against the real Notion API.
/// </summary>
public class HttpClientOptionsTests : IntegrationTestBase
{
    [Fact]
    public async Task NotionClient_Works_With_Externally_Provided_HttpClient()
    {
        // Simulate a console app / non-DI scenario where the caller manages
        // a singleton HttpClient and passes it in via ClientOptions.
        var httpClient = new HttpClient();

        var options = new ClientOptions
        {
            AuthToken = GetEnvironmentVariableRequired("NOTION_AUTH_TOKEN"),
            HttpClient = httpClient
        };

        var client = NotionClientFactory.Create(options);

        var user = await client.Users.MeAsync();

        user.Should().NotBeNull();
        user.Id.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task NotionClient_With_DefaultRetryPolicy_Handles_Normal_Requests()
    {
        // Verify that opting in to the retry policy doesn't break normal (non-error) requests.
        var options = new ClientOptions
        {
            AuthToken = GetEnvironmentVariableRequired("NOTION_AUTH_TOKEN"),
            RetryPolicy = new DefaultRetryPolicy(maxRetries: 2)
        };

        var client = NotionClientFactory.Create(options);

        var user = await client.Users.MeAsync();

        user.Should().NotBeNull();
        user.Id.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task NotionClient_With_RetryPolicy_And_Custom_HttpClient_Respects_External_Pipeline()
    {
        // When an external HttpClient is provided, RetryPolicy in ClientOptions is documented
        // as having no effect — the caller owns the pipeline. Verify normal calls succeed.
        var httpClient = new HttpClient();

        var options = new ClientOptions
        {
            AuthToken = GetEnvironmentVariableRequired("NOTION_AUTH_TOKEN"),
            HttpClient = httpClient,
            RetryPolicy = new DefaultRetryPolicy() // ignored for external HttpClient
        };

        var client = NotionClientFactory.Create(options);

        var user = await client.Users.MeAsync();

        user.Should().NotBeNull();
    }
}
