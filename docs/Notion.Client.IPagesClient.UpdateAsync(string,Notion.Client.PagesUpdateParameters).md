### [Notion.Client](Notion.Client.md 'Notion.Client').[IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

## IPagesClient.UpdateAsync(string, PagesUpdateParameters) Method

Updates page property values for the specified page.  
Properties that are not set via the properties parameter will remain unchanged.

```csharp
System.Threading.Tasks.Task<Notion.Client.Page> UpdateAsync(string pageId, Notion.Client.PagesUpdateParameters pagesUpdateParameters);
```
#### Parameters

<a name='Notion.Client.IPagesClient.UpdateAsync(string,Notion.Client.PagesUpdateParameters).pageId'></a>

`pageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Identifier for a Notion page

<a name='Notion.Client.IPagesClient.UpdateAsync(string,Notion.Client.PagesUpdateParameters).pagesUpdateParameters'></a>

`pagesUpdateParameters` [Notion.Client.PagesUpdateParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PagesUpdateParameters 'Notion.Client.PagesUpdateParameters')

Update property parameters

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Page](Notion.Client.Page.md 'Notion.Client.Page')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Updated [Page](Notion.Client.Page.md 'Notion.Client.Page') object