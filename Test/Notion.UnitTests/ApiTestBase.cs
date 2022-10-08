using System;
using System.Linq;
using Notion.Client;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.Server;

namespace Notion.UnitTests;

public class ApiTestBase : IDisposable
{
    protected readonly ClientOptions ClientOptions;
    protected readonly WireMockServer Server;

    protected ApiTestBase()
    {
        Server = WireMockServer.Start();

        ClientOptions = new ClientOptions
        {
            BaseUrl = Server.Urls.First(),
            AuthToken = "<Token>"
        };
    }

    public void Dispose()
    {
        Server.Stop();
        Server.Dispose();
    }

    protected IRequestBuilder CreateGetRequestBuilder(string path)
    {
        return Request.Create()
            .WithPath(path)
            .UsingGet()
            .WithHeader("Authorization", $"Bearer {ClientOptions.AuthToken}", MatchBehaviour.AcceptOnMatch)
            .WithHeader("Notion-Version", Constants.DefaultNotionVersion, MatchBehaviour.AcceptOnMatch);
    }

    protected IRequestBuilder CreatePostRequestBuilder(string path)
    {
        return Request.Create()
            .WithPath(path)
            .UsingPost()
            .WithHeader("Authorization", $"Bearer {ClientOptions.AuthToken}", MatchBehaviour.AcceptOnMatch)
            .WithHeader("Notion-Version", Constants.DefaultNotionVersion, MatchBehaviour.AcceptOnMatch);
    }

    protected IRequestBuilder CreatePatchRequestBuilder(string path)
    {
        return Request.Create()
            .WithPath(path)
            .UsingPatch()
            .WithHeader("Authorization", $"Bearer {ClientOptions.AuthToken}", MatchBehaviour.AcceptOnMatch)
            .WithHeader("Notion-Version", Constants.DefaultNotionVersion, MatchBehaviour.AcceptOnMatch);
    }
}
