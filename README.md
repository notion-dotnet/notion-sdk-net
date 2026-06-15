<div align="center">
	<h1>Notion SDK for .Net</h1>
	<p>
		<b>A simple and easy to use client for the <a href="https://developers.notion.com">Notion API</a></b>
	</p>
	<br>
</div>

[![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/notion-dotnet/notion-sdk-net)]()
[![GitHub](https://img.shields.io/github/license/notion-dotnet/notion-sdk-net)]()

[![Build Status](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/ci-build.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/ci-build.yml)
[![Build artifacts](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/build-artifacts-code.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/build-artifacts-code.yml)
[![Publish Code](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/publish-code.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/publish-code.yml)
[![CodeQL](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/codeql-analysis.yml)

[![GitHub last commit](https://img.shields.io/github/last-commit/notion-dotnet/notion-sdk-net)]()
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/notion-dotnet/notion-sdk-net)]()
[![GitHub commit activity](https://img.shields.io/github/commit-activity/m/notion-dotnet/notion-sdk-net)]()
[![GitHub commit activity](https://img.shields.io/github/commit-activity/y/notion-dotnet/notion-sdk-net)]()

[![GitHub repo size](https://img.shields.io/github/repo-size/notion-dotnet/notion-sdk-net)]()
[![Lines of code](https://img.shields.io/tokei/lines/github/notion-dotnet/notion-sdk-net)]()

Provides the following packages:

| Package | Downloads | Nuget |
|---|---|---|
| Notion.Net | [![Nuget](https://img.shields.io/nuget/dt/Notion.Net?color=success)](https://www.nuget.org/packages/Notion.Net) | [![Nuget](https://img.shields.io/nuget/v/Notion.Net) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Notion.Net)](https://www.nuget.org/packages/Notion.Net) |



## Installation

.Net CLI

```
dotnet add package Notion.Net
```

**Note:** Default Notion-Version used by NuGet package versions
| Package version | Notion-Version |
| --- | --- |
| 5.0.0-preview+ | 2025-09-03 |
| 4.4.0+ | 2022-06-28 |
| 4.3.0+ | 2022-06-28 | 
| 4.0.0+ | 2022-06-28 | 
| 3.0.0+ | 2022-02-22 |
| 2.0.0+ | 2021-08-16 |
| 1.0.0+ | 2021-05-13 |

## Usage

> Before getting started, you need to [create an integration](https://www.notion.com/my-integrations) and find the token. You can learn more about authorization [here](https://developers.notion.com/docs/authorization).

Import and initialize the client using the integration token created above.

```csharp
var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = "<Token>"
});
```

Make A request to any Endpoint. For example you can call below to fetch the paginated list of users.

```csharp
var usersList = await client.Users.ListAsync();
```

## Dependency Injection

The library provides an extension method to register `INotionClient` with Microsoft dependency injection.
It uses `IHttpClientFactory` internally, which correctly manages `HttpClientHandler` lifetimes to prevent
stale DNS and socket exhaustion in long-running applications.

```csharp
services.AddNotionClient(options => {
  options.AuthToken = "<Token>";
});
```

Then inject `INotionClient` into your services:

```csharp
public class MyService
{
    private readonly INotionClient _notionClient;
    
    public MyService(INotionClient notionClient)
    {
        _notionClient = notionClient;
    }
    
    public async Task<Database> GetDatabaseAsync(string databaseId)
    {
        return await _notionClient.Databases.RetrieveAsync(databaseId);
    }
}
```

### Providing your own HttpClient

For console apps or non-DI scenarios where you manage a long-lived singleton `HttpClient`:

```csharp
var httpClient = new HttpClient();

var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = "<Token>",
    HttpClient = httpClient  // the library uses it as-is and does not dispose it
});
```

## Retry Policy

The library ships with an opt-in exponential-backoff retry policy. When enabled it automatically
retries on HTTP 429 (rate limited) for all methods, and on HTTP 500/503 for idempotent methods
(GET, DELETE). The `Retry-After` response header is honoured for rate-limited responses.

```csharp
var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = "<Token>",
    RetryPolicy = new DefaultRetryPolicy(
        maxRetries: 3,          // default
        initialDelay: TimeSpan.FromSeconds(1),  // doubles each attempt
        maxDelay: TimeSpan.FromSeconds(60)
    )
});
```

Works with DI too:

```csharp
services.AddNotionClient(options =>
{
    options.AuthToken = "<Token>";
    options.RetryPolicy = new DefaultRetryPolicy(maxRetries: 3);
});
```

### Custom retry policy

Implement `IRetryPolicy` to fully control retry behaviour, or subclass `DefaultRetryPolicy`
to override individual aspects:

```csharp
// Full custom implementation — e.g. wrapping Polly
public class PollyRetryPolicy : IRetryPolicy
{
    public bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
        => attempt < 3 && (int)response.StatusCode is 429 or 500 or 503;

    public TimeSpan GetDelay(HttpResponseMessage response, int attempt)
        => TimeSpan.FromSeconds(Math.Pow(2, attempt));
}

// Or subclass DefaultRetryPolicy to tweak a single aspect
public class AggressiveRetryPolicy : DefaultRetryPolicy
{
    public AggressiveRetryPolicy() : base(maxRetries: 5) { }

    public override bool ShouldRetry(HttpResponseMessage response, HttpMethod method, int attempt)
        => base.ShouldRetry(response, method, attempt)
            || (int)response.StatusCode == 502; // also retry on bad gateway
}
```

> **Note:** If the `HttpClient` you supply already has retry in its pipeline (e.g. via Polly registered
> through `IHttpClientFactory`), leave `RetryPolicy` null. Setting both causes nested retries.


## Supported Endpoints

- [x] **Authentication**
  - [x] Create access token
  - [x] Revoke access token  
  - [x] Introspect token (get token status and details)
  - [x] Refresh access token
- [x] **Databases**
  - [x] Retrieve a database
  - [x] Query a database
  - [x] Create a database
  - [x] Update a database
- [x] **Pages**
  - [x] Retrieve a page
  - [x] Create a page
  - [x] Update page properties
  - [x] Retrieve page property item
  - [x] Retrieve page as markdown
  - [x] Update page as markdown
- [x] **Blocks**
  - [x] Retrieve a block
  - [x] Update a block
  - [x] Retrieve block children
  - [x] Append block children
  - [x] Delete a block
- [x] **Comments**
  - [x] Retrieve comments
  - [x] Create comment
- [x] **Users**
  - [x] Retrieve a user
  - [x] List all users
  - [x] Retrieve your token's bot user (me)
- [x] **Search**
  - [x] Search across pages and databases
- [x] **File Uploads**
  - [x] Create file upload
  - [x] Send file upload
  - [x] Complete file upload (for multi-part uploads)
  - [x] List file uploads
  - [x] Retrieve file upload
- [x] **Data Sources**
  - [x] Retrieve a data source
  - [x] Create a data source
  - [x] Update a data source
  - [x] Query a data source
  - [x] List data source templates

## Enable internal logs
The library make use of `ILoggerFactory` interface exposed by `Microsoft.Extensions.Logging`. Which allow you to have ability to enable the internal logs when developing application to get additional information.

To enable logging you need to add the below code at startup of the application.

```csharp
// pass the ILoggerFactory instance
NotionClientLogging.ConfigureLogger(logger);

```

You can set the LogLevel in config file.
```json
{
  "Logging": {
    "LogLevel": {
      "Notion.Client": "Trace"
    }
  }
}
```

You can also refer to the `examples/list-users` example.

## Error Handling

The SDK provides specific exception types for common API errors:

```csharp
try
{
    var page = await client.Pages.RetrieveAsync(pageId);
}
catch (NotionApiRateLimitException rateLimitEx)
{
    // Handle rate limit - check rateLimitEx.RetryAfter for when to retry
    Console.WriteLine($"Rate limited. Retry after: {rateLimitEx.RetryAfter}");
}
catch (NotionApiException apiEx)
{
    // Handle other API errors
    Console.WriteLine($"API Error: {apiEx.NotionAPIErrorCode} - {apiEx.Message}");
}
```

## Examples

The repository includes several example projects to help you get started:

- **[`examples/list-users`](examples/list-users/)** - Basic example showing how to list users and configure logging
- **[`examples/aspnet-core-app`](examples/aspnet-core-app/)** - ASP.NET Core integration example with dependency injection
- **[`examples/print-database-property-name-and-values`](examples/print-database-property-name-and-values/)** - Working with database properties

## More Code Examples

### Creating a Page
```csharp
var newPage = await client.Pages.CreateAsync(new PagesCreateParameters
{
    Parent = new DatabaseParentInput { DatabaseId = databaseId },
    Properties = new Dictionary<string, PropertyValue>
    {
        {
            "Title", new TitlePropertyValue
            {
                Title = new List<RichTextBase>
                {
                    new RichTextText { Text = new Text { Content = "My New Page" } }
                }
            }
        }
    }
});
```

### Creating a Page with Markdown Content

Use the `Markdown` property to supply initial page content as markdown, and `Position` to control
where the page appears within its parent:

```csharp
var newPage = await client.Pages.CreateAsync(
    PagesCreateParametersBuilder
        .Create(new PageParentRequest { PageId = parentPageId })
        .SetMarkdown("## Hello\n\nThis is the initial content.")
        .SetPosition(new PageStartPosition())  // or PageEndPosition / AfterBlockPagePosition
        .Build());
```

### Updating Page Content as Markdown

```csharp
// Insert new content at the end of the page
await client.Pages.UpdateMarkdownAsync(pageId, new InsertContentMarkdownBody
{
    InsertContent = new InsertContentData
    {
        Content = "## New section\n\nAppended content.",
        Position = new EndMarkdownInsertPosition()
    }
});

// Replace all page content
await client.Pages.UpdateMarkdownAsync(pageId, new ReplaceContentMarkdownBody
{
    ReplaceContent = new ReplaceContentData
    {
        NewStr = "# Replaced\n\nEntire page replaced."
    }
});

// Targeted string replacement (like a search-and-replace)
await client.Pages.UpdateMarkdownAsync(pageId, new UpdateContentMarkdownBody
{
    UpdateContent = new UpdateContentData
    {
        Updates = new List<ContentUpdate>
        {
            new ContentUpdate { OldStr = "old text", NewStr = "new text" }
        }
    }
});
```

### Working with Blocks
```csharp
// Append a paragraph block to a page
var appendResponse = await client.Blocks.AppendChildrenAsync(new BlockAppendChildrenRequest
{
    BlockId = pageId,
    Children = new List<ICreateBlock>
    {
        new ParagraphBlock
        {
            Paragraph = new ParagraphBlock.ParagraphData
            {
                RichText = new List<RichTextBase>
                {
                    new RichTextText
                    {
                        Text = new Text { Content = "This is a new paragraph!" }
                    }
                }
            }
        }
    }
});
```

### File Upload
```csharp
// Create file upload
var fileUpload = await client.FileUploads.CreateAsync(new CreateFileUploadRequest
{
    Name = "example.pdf",
    FileType = FileType.Pdf,
    FileSize = fileSize,
    ExpiresTime = DateTime.UtcNow.AddHours(1)
});

// Send the file
var sendResponse = await client.FileUploads.SendAsync(new SendFileUploadRequest
{
    FileUploadId = fileUpload.Id,
    FileContent = fileBytes
});
```

### Data Sources
```csharp
// Retrieve a data source
var dataSource = await client.DataSources.RetrieveAsync(new RetrieveDataSourceRequest
{
    DataSourceId = dataSourceId
});

// Query a data source
var queryResult = await client.DataSources.QueryAsync(new QueryDataSourceRequest
{
    DataSourceId = dataSourceId,
    Filter = new DataSourceFilter { /* your filter criteria */ }
});

// List data source templates
var templates = await client.DataSources.ListTemplatesAsync(new ListDataSourceTemplatesRequest());
```

## Contributors
This project exists thanks to all the people who contribute.

[![contributor image](https://contrib.rocks/image?repo=notion-dotnet/notion-sdk-net)](https://github.com/notion-dotnet/notion-sdk-net/graphs/contributors)

## Contribution Guideline

Hello! Thank you for choosing to help contribute to this open source library. There are many ways you can contribute and help is always welcome. You can read the detailed [Contribution Guideline](https://github.com/notion-dotnet/notion-sdk-net/blob/main/CONTRIBUTING.md) defined here - we will continue to improve it.
