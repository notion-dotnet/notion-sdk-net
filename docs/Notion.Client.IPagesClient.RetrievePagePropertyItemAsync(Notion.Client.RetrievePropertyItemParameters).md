### [Notion.Client](Notion.Client.md 'Notion.Client').[IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

## IPagesClient.RetrievePagePropertyItemAsync(RetrievePropertyItemParameters) Method

Retrieves a property_item object for a given pageId and propertyId. Depending on the property type, the object  
returned will either be a value or a paginated list of property item values.

```csharp
System.Threading.Tasks.Task<Notion.Client.IPropertyItemObject> RetrievePagePropertyItemAsync(Notion.Client.RetrievePropertyItemParameters retrievePropertyItemParameters);
```
#### Parameters

<a name='Notion.Client.IPagesClient.RetrievePagePropertyItemAsync(Notion.Client.RetrievePropertyItemParameters).retrievePropertyItemParameters'></a>

`retrievePropertyItemParameters` [Notion.Client.RetrievePropertyItemParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.RetrievePropertyItemParameters 'Notion.Client.RetrievePropertyItemParameters')

Property body and query parameters

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[IPropertyItemObject](Notion.Client.IPropertyItemObject.md 'Notion.Client.IPropertyItemObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[IPropertyItemObject](Notion.Client.IPropertyItemObject.md 'Notion.Client.IPropertyItemObject')