using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using WireMock.ResponseBuilders;
using Xunit;

namespace Notion.UnitTests;

public class RetryPolicyTests : ApiTestBase
{
    private const string PageId = "251d2b5f-268c-4de2-afe9-c71ff92ca95c";
    private const string BlockId = "3c357473-a281-49a4-88c0-10d2b245a589";

    private INotionClient CreateClientWithPolicy(IRetryPolicy policy)
    {
        var options = new ClientOptions
        {
            BaseUrl = Server.Urls[0],
            AuthToken = ClientOptions.AuthToken,
            RetryPolicy = policy
        };

        return NotionClientFactory.Create(options);
    }

    // Very short delays so unit tests don't become slow.
    private static DefaultRetryPolicy FastPolicy(int maxRetries = 3)
        => new DefaultRetryPolicy(
            maxRetries: maxRetries,
            initialDelay: TimeSpan.FromMilliseconds(1),
            maxDelay: TimeSpan.FromMilliseconds(10));

    // -------------------------------------------------------------------------
    // HTTP 429 — retried for all methods
    // -------------------------------------------------------------------------

    [Fact]
    public async Task Retries_On_429_For_Get_Then_Succeeds()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);
        var json = await File.ReadAllTextAsync("data/pages/PageObjectShouldHaveUrlPropertyResponse.json");

        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("429-get")
            .WillSetStateTo("retried")
            .RespondWith(Response.Create().WithStatusCode(429));

        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("429-get")
            .WhenStateIs("retried")
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(json));

        var client = CreateClientWithPolicy(FastPolicy(maxRetries: 1));

        var page = await client.Pages.RetrieveAsync(PageId);

        page.Should().NotBeNull();
        Server.LogEntries.Should().HaveCount(2);
    }

    [Fact]
    public async Task Retries_On_429_For_Post_Then_Succeeds()
    {
        var path = ApiEndpoints.PagesApiUrls.Create();
        var json = await File.ReadAllTextAsync("data/pages/CreatePageResponse.json");

        Server.Given(CreatePostRequestBuilder(path))
            .InScenario("429-post")
            .WillSetStateTo("retried")
            .RespondWith(Response.Create().WithStatusCode(429));

        Server.Given(CreatePostRequestBuilder(path))
            .InScenario("429-post")
            .WhenStateIs("retried")
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(json));

        var client = CreateClientWithPolicy(FastPolicy(maxRetries: 1));

        var page = await client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new DatabaseParentRequest { DatabaseId = "3c357473-a281-49a4-88c0-10d2b245a589" })
                .Build());

        page.Should().NotBeNull();
        Server.LogEntries.Should().HaveCount(2);
    }

    // -------------------------------------------------------------------------
    // HTTP 500 — retried for GET / DELETE only
    // -------------------------------------------------------------------------

    [Fact]
    public async Task Retries_On_500_For_Get_Then_Succeeds()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);
        var json = await File.ReadAllTextAsync("data/pages/PageObjectShouldHaveUrlPropertyResponse.json");

        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("500-get")
            .WillSetStateTo("retried")
            .RespondWith(Response.Create()
                .WithStatusCode(500)
                .WithBody("{\"code\":\"internal_server_error\",\"message\":\"Internal server error\"}"));

        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("500-get")
            .WhenStateIs("retried")
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(json));

        var client = CreateClientWithPolicy(FastPolicy(maxRetries: 1));

        var page = await client.Pages.RetrieveAsync(PageId);

        page.Should().NotBeNull();
        Server.LogEntries.Should().HaveCount(2);
    }

    [Fact]
    public async Task Does_Not_Retry_On_500_For_Post()
    {
        var path = ApiEndpoints.PagesApiUrls.Create();

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(Response.Create()
                .WithStatusCode(500)
                .WithBody("{\"code\":\"internal_server_error\",\"message\":\"Internal server error\"}"));

        var client = CreateClientWithPolicy(FastPolicy());

        var act = () => client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new DatabaseParentRequest { DatabaseId = "db-id" })
                .Build());

        await act.Should().ThrowAsync<NotionApiException>();
        Server.LogEntries.Should().HaveCount(1);
    }

    // -------------------------------------------------------------------------
    // HTTP 503 — retried for GET / DELETE only
    // -------------------------------------------------------------------------

    [Fact]
    public async Task Retries_On_503_For_Delete_Then_Succeeds()
    {
        var path = ApiEndpoints.BlocksApiUrls.Delete(BlockId);

        Server.Given(CreateDeleteRequestBuilder(path))
            .InScenario("503-delete")
            .WillSetStateTo("retried")
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithBody("{\"code\":\"service_unavailable\",\"message\":\"Service unavailable\"}"));

        Server.Given(CreateDeleteRequestBuilder(path))
            .InScenario("503-delete")
            .WhenStateIs("retried")
            .RespondWith(Response.Create().WithStatusCode(200));

        var client = CreateClientWithPolicy(FastPolicy(maxRetries: 1));

        await client.Blocks.DeleteAsync(BlockId); // no exception = success

        Server.LogEntries.Should().HaveCount(2);
    }

    [Fact]
    public async Task Does_Not_Retry_On_503_For_Post()
    {
        var path = ApiEndpoints.PagesApiUrls.Create();

        Server.Given(CreatePostRequestBuilder(path))
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithBody("{\"code\":\"service_unavailable\",\"message\":\"Service unavailable\"}"));

        var client = CreateClientWithPolicy(FastPolicy());

        var act = () => client.Pages.CreateAsync(
            PagesCreateParametersBuilder
                .Create(new DatabaseParentRequest { DatabaseId = "db-id" })
                .Build());

        await act.Should().ThrowAsync<NotionApiException>();
        Server.LogEntries.Should().HaveCount(1);
    }

    // -------------------------------------------------------------------------
    // MaxRetries limit
    // -------------------------------------------------------------------------

    [Fact]
    public async Task Stops_After_MaxRetries_And_Throws()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(Response.Create()
                .WithStatusCode(429)
                .WithBody("{\"code\":\"rate_limited\",\"message\":\"Rate limited\"}"));

        var client = CreateClientWithPolicy(FastPolicy(maxRetries: 2));

        var act = () => client.Pages.RetrieveAsync(PageId);

        await act.Should().ThrowAsync<NotionApiException>();
        // original + 2 retries = 3 total requests
        Server.LogEntries.Should().HaveCount(3);
    }

    // -------------------------------------------------------------------------
    // No policy = no retry
    // -------------------------------------------------------------------------

    [Fact]
    public async Task No_Retry_When_RetryPolicy_Is_Null()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(Response.Create()
                .WithStatusCode(429)
                .WithBody("{\"code\":\"rate_limited\",\"message\":\"Rate limited\"}"));

        var client = CreateClientWithPolicy(policy: null);

        var act = () => client.Pages.RetrieveAsync(PageId);

        await act.Should().ThrowAsync<NotionApiException>();
        Server.LogEntries.Should().HaveCount(1);
    }

    // -------------------------------------------------------------------------
    // Custom IRetryPolicy extensibility
    // -------------------------------------------------------------------------

    [Fact]
    public async Task Custom_IRetryPolicy_Is_Invoked_And_Controls_Behaviour()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);

        Server.Given(CreateGetRequestBuilder(path))
            .RespondWith(Response.Create()
                .WithStatusCode(500)
                .WithBody("{\"code\":\"internal_server_error\",\"message\":\"Internal server error\"}"));

        var policy = new NeverRetryPolicy();
        var client = CreateClientWithPolicy(policy);

        var act = () => client.Pages.RetrieveAsync(PageId);

        await act.Should().ThrowAsync<NotionApiException>();
        // Custom policy said "don't retry", so exactly one request was made.
        Server.LogEntries.Should().HaveCount(1);
        policy.ShouldRetryCallCount.Should().Be(1);
    }

    [Fact]
    public async Task Subclassed_DefaultRetryPolicy_Can_Override_ShouldRetry()
    {
        var path = ApiEndpoints.PagesApiUrls.Retrieve(PageId);
        var json = await File.ReadAllTextAsync("data/pages/PageObjectShouldHaveUrlPropertyResponse.json");

        // Retry on 500 even for GET — same as default — but also retry on 404 (custom override)
        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("custom-override")
            .WillSetStateTo("retried")
            .RespondWith(Response.Create()
                .WithStatusCode(500)
                .WithBody("{\"code\":\"internal_server_error\",\"message\":\"Internal server error\"}"));

        Server.Given(CreateGetRequestBuilder(path))
            .InScenario("custom-override")
            .WhenStateIs("retried")
            .RespondWith(Response.Create().WithStatusCode(200).WithBody(json));

        var policy = new AlwaysRetryOncePolicy();
        var client = CreateClientWithPolicy(policy);

        var page = await client.Pages.RetrieveAsync(PageId);

        page.Should().NotBeNull();
        Server.LogEntries.Should().HaveCount(2);
    }

    // -------------------------------------------------------------------------
    // Test helpers
    // -------------------------------------------------------------------------

    /// <summary>Custom policy that never retries — used to verify IRetryPolicy is called.</summary>
    private sealed class NeverRetryPolicy : IRetryPolicy
    {
        public int ShouldRetryCallCount { get; private set; }

        public bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
        {
            ShouldRetryCallCount++;
            return false;
        }

        public TimeSpan GetDelay(HttpResponseMessage response, int attempt) => TimeSpan.Zero;
    }

    /// <summary>Subclass of DefaultRetryPolicy that always retries once regardless of status code.</summary>
    private sealed class AlwaysRetryOncePolicy : DefaultRetryPolicy
    {
        public AlwaysRetryOncePolicy()
            : base(maxRetries: 1, initialDelay: TimeSpan.FromMilliseconds(1)) { }

        public override bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
            => attempt < MaxRetries;
    }
}
