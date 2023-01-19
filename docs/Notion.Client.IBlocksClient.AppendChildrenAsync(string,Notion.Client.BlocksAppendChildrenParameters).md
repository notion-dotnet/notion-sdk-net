### [Notion.Client](Notion.Client.md 'Notion.Client').[IBlocksClient](Notion.Client.IBlocksClient.md 'Notion.Client.IBlocksClient')

## IBlocksClient.AppendChildrenAsync(string, BlocksAppendChildrenParameters) Method

Creates and appends new children blocks to the parent block_id specified.

```csharp
System.Threading.Tasks.Task<Notion.Client.PaginatedList<Notion.Client.IBlock>> AppendChildrenAsync(string blockId, Notion.Client.BlocksAppendChildrenParameters parameters=null);
```
#### Parameters

<a name='Notion.Client.IBlocksClient.AppendChildrenAsync(string,Notion.Client.BlocksAppendChildrenParameters).blockId'></a>

`blockId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Identifier for a block

<a name='Notion.Client.IBlocksClient.AppendChildrenAsync(string,Notion.Client.BlocksAppendChildrenParameters).parameters'></a>

`parameters` [Notion.Client.BlocksAppendChildrenParameters](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.BlocksAppendChildrenParameters 'Notion.Client.BlocksAppendChildrenParameters')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.PaginatedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[Notion.Client.IBlock](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.IBlock 'Notion.Client.IBlock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.PaginatedList-1 'Notion.Client.PaginatedList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A paginated list of newly created first level children block objects.