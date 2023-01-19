### [Notion.Client](Notion.Client.md 'Notion.Client').[IPagesClient](Notion.Client.IPagesClient.md 'Notion.Client.IPagesClient')

## IPagesClient.UpdatePropertiesAsync(string, IDictionary<string,PropertyValue>) Method

Updates page property values for the specified page.  
Note: Properties that are not set via the properties parameter will remain unchanged.

```csharp
System.Threading.Tasks.Task<Notion.Client.Page> UpdatePropertiesAsync(string pageId, System.Collections.Generic.IDictionary<string,Notion.Client.PropertyValue> updatedProperties);
```
#### Parameters

<a name='Notion.Client.IPagesClient.UpdatePropertiesAsync(string,System.Collections.Generic.IDictionary_string,Notion.Client.PropertyValue_).pageId'></a>

`pageId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Identifier for a Notion page

<a name='Notion.Client.IPagesClient.UpdatePropertiesAsync(string,System.Collections.Generic.IDictionary_string,Notion.Client.PropertyValue_).updatedProperties'></a>

`updatedProperties` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[PropertyValue](Notion.Client.PropertyValue.md 'Notion.Client.PropertyValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')

Property values to update for this page. The keys are the names or IDs of the property  
and the values are property values.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Page](Notion.Client.Page.md 'Notion.Client.Page')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Updated [Page](Notion.Client.Page.md 'Notion.Client.Page') object