### [Notion.Client](Notion.Client.md 'Notion.Client').[IUsersClient](Notion.Client.IUsersClient.md 'Notion.Client.IUsersClient')

## IUsersClient.ListAsync() Method

Returns a paginated list of Users for the workspace.  
The response may contain fewer than page_size of results.

```csharp
System.Threading.Tasks.Task<Notion.Client.PaginatedList<Notion.Client.User>> ListAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.PaginatedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[Notion.Client.User](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.User 'Notion.Client.User')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[Notion.Client.PaginatedList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')