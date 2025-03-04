### [Notion.Client](Notion.Client.md 'Notion.Client').[IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

## IPagesClient.CreateAsync(PagesCreateParameters) Method

Creates a new page in the specified database or as a child of an existing page.  
If the parent is a database, the  
[property values](https://developers.notion.com/reference-link/page#property-value-object 'https://developers.notion.com/reference-link/page#property-value-object') of the  
new page in the properties parameter must conform to the parent  
[database](https://developers.notion.com/reference-link/database 'https://developers.notion.com/reference-link/database')'s property schema.  
If the parent is a page, the only valid property is <strong>title</strong>.

```csharp
System.Threading.Tasks.Task<Notion.Client.Page> CreateAsync(Notion.Client.PagesCreateParameters pagesCreateParameters);
```
#### Parameters

<a name='Notion.Client.IPagesClient.CreateAsync(Notion.Client.PagesCreateParameters).pagesCreateParameters'></a>

`pagesCreateParameters` [Notion.Client.PagesCreateParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PagesCreateParameters 'Notion.Client.PagesCreateParameters')

Create page parameters

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Page](Notion.Client.Page.md 'Notion.Client.Page')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Created [Page](Notion.Client.Page.md 'Notion.Client.Page') object.