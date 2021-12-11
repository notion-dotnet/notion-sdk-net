using System.Collections.Generic;

namespace Notion.Client
{
    public class BlocksAppendChildrenParameters : IBlocksAppendChildrenBodyParameters
    {
        public IEnumerable<IBlock> Children { get; set; }
    }
}
