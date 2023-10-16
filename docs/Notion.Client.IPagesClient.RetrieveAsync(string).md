### [Notion.Client](Notion.Client.md 'Notion.Client').[IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

## IPagesClient.RetrieveAsync(string) Method

Retrieves a Page object using the ID specified.

```csharp
System.Threading.Tasks.Task<Notion.Client.Page> RetrieveAsync(string pageId);
```
#### Parameters

<a name='Notion.Client.IPagesClient.RetrieveAsync(string).pageId'></a>

`pageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Identifier for a Notion page

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Page](Notion.Client.Page.md 'Notion.Client.Page')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[Page](Notion.Client.Page.md 'Notion.Client.Page')