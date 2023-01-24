using System;
using Notion.Client;

namespace Notion.IntegrationTests;

public abstract class IntegrationTestBase
{
    protected readonly INotionClient Client;
    protected readonly string ParentPageId;
    protected readonly string ParentDatabaseId;

    protected IntegrationTestBase()
    {
        var options = new ClientOptions { AuthToken = Environment.GetEnvironmentVariable("NOTION_AUTH_TOKEN") };

        Client = NotionClientFactory.Create(options);

        ParentPageId = Environment.GetEnvironmentVariable("NOTION_PARENT_PAGE_ID")
                       ?? throw new InvalidOperationException("Parent page id is required.");

        ParentDatabaseId = Environment.GetEnvironmentVariable("NOTION_PARENT_DATABASE_ID")
                           ?? throw new InvalidOperationException("Parent database id is required.");
    }
}
