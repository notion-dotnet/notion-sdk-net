### [Notion.Client](Notion.Client.md 'Notion.Client')

## IBlocksClient Interface

```csharp
public interface IBlocksClient
```

| Methods | |
| :--- | :--- |
| [AppendChildrenAsync(string, BlocksAppendChildrenParameters)](Notion.Client.IBlocksClient.AppendChildrenAsync(string,Notion.Client.BlocksAppendChildrenParameters).md 'Notion.Client.IBlocksClient.AppendChildrenAsync(string, Notion.Client.BlocksAppendChildrenParameters)') | Creates and appends new children blocks to the parent block_id specified. |
| [DeleteAsync(string)](Notion.Client.IBlocksClient.DeleteAsync(string).md 'Notion.Client.IBlocksClient.DeleteAsync(string)') | Sets a Block object, including page blocks, to archived: true using the ID specified. |
| [RetrieveAsync(string)](Notion.Client.IBlocksClient.RetrieveAsync(string).md 'Notion.Client.IBlocksClient.RetrieveAsync(string)') | Retrieves a Block object using the ID specified. |
| [UpdateAsync(string, IUpdateBlock)](Notion.Client.IBlocksClient.UpdateAsync(string,Notion.Client.IUpdateBlock).md 'Notion.Client.IBlocksClient.UpdateAsync(string, Notion.Client.IUpdateBlock)') | Updates the content for the specified block_id based on the block type. |
