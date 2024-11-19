### [Notion.Client](Notion.Client.md 'Notion.Client').[UsersClient](Notion.Client.UsersClient.md 'Notion.Client.UsersClient')

## UsersClient.MeAsync() Method

Retrieves the bot User associated with the API token provided in the authorization header.

```csharp
public System.Threading.Tasks.Task<Notion.Client.User> MeAsync();
```

Implements [MeAsync()](Notion.Client.IUsersClient.MeAsync().md 'Notion.Client.IUsersClient.MeAsync()')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.User](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.User 'Notion.Client.User')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
User object of type bot having an owner field with information about the person who authorized the  
integration.