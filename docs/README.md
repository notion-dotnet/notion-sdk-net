# Notion SDK for .Net

A simple and easy to use client for the [Notion API](https://developers.notion.com)

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

## Register using Microsoft.Extensions.DependencyInjection

Library also provides extension method to register NotionClient with Microsoft dependency injection.

```csharp
services.AddNotionClient(options => {
  options.AuthToken = "<Token>";
});
```


## Supported Endpoints

- [x] **Authentication**
  - [x] Create access token
  - [x] Revoke access token  
  - [x] Introspect token (get token status and details)
  - [x] Refresh access token
- [x] **Databases**
  - [x] Retrieve a database
  - [x] Create a database
  - [x] Update a database
- [x] **Pages**
  - [x] Retrieve a page
  - [x] Create a page
  - [x] Update page properties
  - [x] Retrieve page property item
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

You can also refer `examples/list-users` example.

## Contribution Guideline

Hello! Thank you for choosing to help contribute to this open source library. There are many ways you can contribute and help is always welcome. You can read the detailed [Contribution Guideline](https://github.com/notion-dotnet/notion-sdk-net/blob/main/CONTRIBUTING.md) defined here - we will continue to improve it.
