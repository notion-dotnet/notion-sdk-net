### [Notion.Client](Notion.Client.md 'Notion.Client')

## ISearchClient Interface

```csharp
public interface ISearchClient
```

| Methods | |
| :--- | :--- |
| [SearchAsync(SearchParameters)](Notion.Client.ISearchClient.SearchAsync(Notion.Client.SearchParameters).md 'Notion.Client.ISearchClient.SearchAsync(Notion.Client.SearchParameters)') | Searches all original pages, databases, and child pages/databases that are shared with the integration.<br/>It will not return linked databases, since these duplicate their source databases. |
