### [Notion.Client](Notion.Client.md 'Notion.Client')

## RollupValue Class

Object containing rollup type-specific data.

```csharp
public class RollupValue
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RollupValue

| Properties | |
| :--- | :--- |
| [Array](Notion.Client.RollupValue.Array.md 'Notion.Client.RollupValue.Array') | Array rollup property values contain an array of element objects.<br/>Array containing the property value object will not contain value for Id field |
| [Date](Notion.Client.RollupValue.Date.md 'Notion.Client.RollupValue.Date') | Date rollup property values contain a date property value. |
| [Number](Notion.Client.RollupValue.Number.md 'Notion.Client.RollupValue.Number') | Number rollup property values contain a number |
| [Type](Notion.Client.RollupValue.Type.md 'Notion.Client.RollupValue.Type') | The type of rollup. Possible values are "number", "date", and "array". |
