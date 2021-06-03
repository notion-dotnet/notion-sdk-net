<div align="center>
    <h1>Notion SDK for .Net</h1>
    <p>
        <b>A simple and easy to use client for the <a href="https://developers.notion.com">Notion API</a></b>
    </p>
</div>

![Build Status](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/ci_build.yml/badge.svg)

![Nuget](https://img.shields.io/nuget/v/Notion.Net)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Notion.Net)

## Installation

.Net CLI

```
dotnet add package Notion.Net
```

## Usage

> Before getting started, you need to [create an integration](https://www.notion.com/my-integrations) and find the token. You can learn more about authorization [here](https://developers.notion.com/docs/authorization).

Import and initialize the client using the integration token created above.

![image](https://user-images.githubusercontent.com/18693839/119268863-79925b00-bc12-11eb-92cb-d5a9a8c57fdc.png)

Make A request to any Endpoint. For example you can call below to fetch the paginated list of users.

![image](https://user-images.githubusercontent.com/18693839/119268924-ae9ead80-bc12-11eb-9d1a-925267896d9e.png)

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

## Contribution Guideline

At the moment I haven't got any specific guidelines for the project. Everyone are welcome to contribute.
