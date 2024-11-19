### [Notion.Client](Notion.Client.md 'Notion.Client').[ISearchClient](Notion.Client.ISearchClient.md 'Notion.Client.ISearchClient')

## ISearchClient.SearchAsync(SearchParameters) Method

Searches all original pages, databases, and child pages/databases that are shared with the integration.  
It will not return linked databases, since these duplicate their source databases.

```csharp
System.Threading.Tasks.Task<Notion.Client.PaginatedList<Notion.Client.IObject>> SearchAsync(Notion.Client.SearchParameters parameters);
```
#### Parameters

<a name='Notion.Client.ISearchClient.SearchAsync(Notion.Client.SearchParameters).parameters'></a>

`parameters` [Notion.Client.SearchParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.SearchParameters 'Notion.Client.SearchParameters')

Search filters and body parameters

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.PaginatedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[Notion.Client.IObject](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.IObject 'Notion.Client.IObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[Notion.Client.PaginatedList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')