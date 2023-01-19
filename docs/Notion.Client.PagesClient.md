### [Notion.Client](Notion.Client.md 'Notion.Client')

## PagesClient Class

```csharp
public class PagesClient :
Notion.Client.IPagesClient
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PagesClient

Implements [IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

| Methods | |
| :--- | :--- |
| [CreateAsync(PagesCreateParameters)](Notion.Client.PagesClient.CreateAsync(Notion.Client.PagesCreateParameters).md 'Notion.Client.PagesClient.CreateAsync(Notion.Client.PagesCreateParameters)') | Creates a new page in the specified database or as a child of an existing page.<br/>If the parent is a database, the<br/>[property values](https://developers.notion.com/reference-link/page#property-value-object 'https://developers.notion.com/reference-link/page#property-value-object') of the<br/>new page in the properties parameter must conform to the parent<br/>[database](https://developers.notion.com/reference-link/database 'https://developers.notion.com/reference-link/database')'s property schema.<br/>If the parent is a page, the only valid property is <strong>title</strong>. |
