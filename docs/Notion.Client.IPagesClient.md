### [Notion.Client](Notion.Client.md 'Notion.Client')

## IPagesClient Interface

```csharp
public interface IPagesClient
```

Derived  
&#8627; [PagesClient](Notion.Client.PagesClient.md 'Notion.Client.PagesClient')

| Methods | |
| :--- | :--- |
| [CreateAsync(PagesCreateParameters)](Notion.Client.IPagesClient.CreateAsync(Notion.Client.PagesCreateParameters).md 'Notion.Client.IPagesClient.CreateAsync(Notion.Client.PagesCreateParameters)') | Creates a new page in the specified database or as a child of an existing page.<br/>If the parent is a database, the<br/>[property values](https://developers.notion.com/reference-link/page#property-value-object 'https://developers.notion.com/reference-link/page#property-value-object') of the<br/>new page in the properties parameter must conform to the parent<br/>[database](https://developers.notion.com/reference-link/database 'https://developers.notion.com/reference-link/database')'s property schema.<br/>If the parent is a page, the only valid property is <strong>title</strong>. |
| [RetrieveAsync(string)](Notion.Client.IPagesClient.RetrieveAsync(string).md 'Notion.Client.IPagesClient.RetrieveAsync(string)') | Retrieves a Page object using the ID specified. |
| [RetrievePagePropertyItemAsync(RetrievePropertyItemParameters)](Notion.Client.IPagesClient.RetrievePagePropertyItemAsync(Notion.Client.RetrievePropertyItemParameters).md 'Notion.Client.IPagesClient.RetrievePagePropertyItemAsync(Notion.Client.RetrievePropertyItemParameters)') | Retrieves a property_item object for a given pageId and propertyId. Depending on the property type, the object<br/>returned will either be a value or a paginated list of property item values. |
| [UpdateAsync(string, PagesUpdateParameters)](Notion.Client.IPagesClient.UpdateAsync(string,Notion.Client.PagesUpdateParameters).md 'Notion.Client.IPagesClient.UpdateAsync(string, Notion.Client.PagesUpdateParameters)') | Updates page property values for the specified page.<br/>Properties that are not set via the properties parameter will remain unchanged. |
| [UpdatePropertiesAsync(string, IDictionary&lt;string,PropertyValue&gt;)](Notion.Client.IPagesClient.UpdatePropertiesAsync(string,System.Collections.Generic.IDictionary_string,Notion.Client.PropertyValue_).md 'Notion.Client.IPagesClient.UpdatePropertiesAsync(string, System.Collections.Generic.IDictionary<string,Notion.Client.PropertyValue>)') | Updates page property values for the specified page.<br/>Note: Properties that are not set via the properties parameter will remain unchanged. |
