### [Notion.Client](Notion.Client.md 'Notion.Client')

## IUsersClient Interface

```csharp
public interface IUsersClient
```

Derived  
&#8627; [UsersClient](Notion.Client.UsersClient.md 'Notion.Client.UsersClient')

| Methods | |
| :--- | :--- |
| [ListAsync()](Notion.Client.IUsersClient.ListAsync().md 'Notion.Client.IUsersClient.ListAsync()') | Returns a paginated list of Users for the workspace.<br/>The response may contain fewer than page_size of results. |
| [MeAsync()](Notion.Client.IUsersClient.MeAsync().md 'Notion.Client.IUsersClient.MeAsync()') | Retrieves the bot User associated with the API token provided in the authorization header. |
| [RetrieveAsync(string)](Notion.Client.IUsersClient.RetrieveAsync(string).md 'Notion.Client.IUsersClient.RetrieveAsync(string)') | Retrieves a User using the ID specified. |
