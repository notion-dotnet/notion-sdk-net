### [Notion.Client](Notion.Client.md 'Notion.Client').[IDatabasesClient](Notion.Client.IDatabasesClient.md 'Notion.Client.IDatabasesClient')

## IDatabasesClient.QueryAsync(string, DatabasesQueryParameters) Method

Gets a list of Pages contained in the database, filtered and ordered according to the  
filter conditions and sort criteria provided in the request. The response may contain  
fewer than `page_size` of results.

```csharp
System.Threading.Tasks.Task<Notion.Client.PaginatedList<Notion.Client.Page>> QueryAsync(string databaseId, Notion.Client.DatabasesQueryParameters databasesQueryParameters);
```
#### Parameters

<a name='Notion.Client.IDatabasesClient.QueryAsync(string,Notion.Client.DatabasesQueryParameters).databaseId'></a>

`databaseId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Notion.Client.IDatabasesClient.QueryAsync(string,Notion.Client.DatabasesQueryParameters).databasesQueryParameters'></a>

`databasesQueryParameters` [Notion.Client.DatabasesQueryParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.DatabasesQueryParameters 'Notion.Client.DatabasesQueryParameters')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.PaginatedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[Page](Notion.Client.Page.md 'Notion.Client.Page')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[Notion.Client.PaginatedList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')