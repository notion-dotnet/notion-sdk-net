# Notion SDK for .Net

A simple and easy to use client for the [Notion API](https://developers.notion.com)

## Installation

.Net CLI

```
dotnet add package Notion.Net
```

> Note: From Nuget 2.0.0 notion client sdk default sets the Notion-Version header to 2021-08-16.

## Usage

> Before getting started, you need to [create an integration](https://www.notion.com/my-integrations) and find the token. You can learn more about authorization [here](https://developers.notion.com/docs/authorization).

Import and initialize the client using the integration token created above.

```csharp
var client = new NotionClient(new ClientOptions
{
    AuthToken = "<Token>"
});
```

Make A request to any Endpoint. For example you can call below to fetch the paginated list of users.

```csharp
var usersList = await client.Users.ListAsync();
```

### Querying a database

After you initialized your client and got an id of a database, you can query it for any contained pages. You can add filters and sorts to your request. Here is a simple example:

```C#
// Date filter for page property called "When"
var dateFilter = new DateFilter("When", onOrAfter: DateTime.Now);

var queryParams = new DatabasesQueryParameters { Filter = dateFilter };
var pages = await client.Databases.QueryAsync(databaseId, queryParams);
```

Filters constructors contain all possible filter conditions, but you need to choose only condition per filter, all other should be `null`. So, for example this code would not filter by 2 conditions as one might expect:

```C#
var filter = new TextFilter("Name", startsWith: "Mr", contains: "John"); // WRONG FILTER USAGE

```

To use complex filters, use class `CompoundFilter`. It allows adding many filters and even nesting compound filters into each other (it works as filter group in Notion interface). Here is an example of filter that would return pages that were due in past month AND either had a certain assignee OR had high urgency:

```C#
var selectFilter = new SelectFilter("Urgency", equal: "High");
var assigneeFilter = new PeopleFilter("Assignee", contains: "some-uuid");
var dateFilter = new DateFilter("Due", pastMonth: new Dictionary<string, object>());

var orGroup = new List<Filter> { assigneeFilter, selectFilter };
var complexFiler = new CompoundFilter(
    and: new List<Filter> { dateFilter, new CompoundFilter(or: orGroup) }
);
```

## Supported Endpoints

- [x] Databases
  - [x] Query a database
  - [x] Create a database
  - [x] Update database
  - [x] Retrieve a database
  - [x] List databases (Deprecated: use Search API instead)
- [x] Pages
  - [x] Retrieve a page
  - [x] Create a page
  - [x] Update page
- [x] Blocks
  - [x] Retrieve a block
  - [x] Update a block
  - [x] Retrieve block children
  - [x] Append block children
  - [x] Delete a block
- [x] Users
  - [x] Retrieve a User
  - [x] List all users
- [x] Search

## Contribution Guideline

Hello! Thank you for choosing to help contribute to this open source library. There are many ways you can contribute and help is always welcome. You can read the detailed [Contribution Guideline](https://github.com/notion-dotnet/notion-sdk-net/blob/main/CONTRIBUTING.md) defined here - we will continue to improve it.
