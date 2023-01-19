### [Notion.Client](Notion.Client.md 'Notion.Client')

## IDatabasesClient Interface

```csharp
public interface IDatabasesClient
```

| Methods | |
| :--- | :--- |
| [CreateAsync(DatabasesCreateParameters)](Notion.Client.IDatabasesClient.CreateAsync(Notion.Client.DatabasesCreateParameters).md 'Notion.Client.IDatabasesClient.CreateAsync(Notion.Client.DatabasesCreateParameters)') | Creates a database as a subpage in the specified parent page, with the specified properties schema. |
| [QueryAsync(string, DatabasesQueryParameters)](Notion.Client.IDatabasesClient.QueryAsync(string,Notion.Client.DatabasesQueryParameters).md 'Notion.Client.IDatabasesClient.QueryAsync(string, Notion.Client.DatabasesQueryParameters)') | Gets a list of Pages contained in the database, filtered and ordered according to the<br/>filter conditions and sort criteria provided in the request. The response may contain<br/>fewer than `page_size` of results. |
| [RetrieveAsync(string)](Notion.Client.IDatabasesClient.RetrieveAsync(string).md 'Notion.Client.IDatabasesClient.RetrieveAsync(string)') | Retrieves a Database object using the ID specified. |
| [UpdateAsync(string, DatabasesUpdateParameters)](Notion.Client.IDatabasesClient.UpdateAsync(string,Notion.Client.DatabasesUpdateParameters).md 'Notion.Client.IDatabasesClient.UpdateAsync(string, Notion.Client.DatabasesUpdateParameters)') | Updates an existing database as specified by the parameters. |
