using System.Collections.Generic;

namespace Notion.Client
{
    // TODO: need an input version of Block
    public interface IBlocksAppendChildrenBodyParameters
    {
        IEnumerable<Block> Children { get; set; }
    }
}
