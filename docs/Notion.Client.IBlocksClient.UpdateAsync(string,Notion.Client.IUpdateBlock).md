### [Notion.Client](Notion.Client.md 'Notion.Client').[IBlocksClient](Notion.Client.IBlocksClient.md 'Notion.Client.IBlocksClient')

## IBlocksClient.UpdateAsync(string, IUpdateBlock) Method

Updates the content for the specified block_id based on the block type.

```csharp
System.Threading.Tasks.Task<Notion.Client.IBlock> UpdateAsync(string blockId, Notion.Client.IUpdateBlock updateBlock);
```
#### Parameters

<a name='Notion.Client.IBlocksClient.UpdateAsync(string,Notion.Client.IUpdateBlock).blockId'></a>

`blockId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Notion.Client.IBlocksClient.UpdateAsync(string,Notion.Client.IUpdateBlock).updateBlock'></a>

`updateBlock` [Notion.Client.IUpdateBlock](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.IUpdateBlock 'Notion.Client.IUpdateBlock')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Notion.Client.IBlock](https://docs.microsoft.com/en-us/dotnet/api/Notion.Client.IBlock 'Notion.Client.IBlock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Block