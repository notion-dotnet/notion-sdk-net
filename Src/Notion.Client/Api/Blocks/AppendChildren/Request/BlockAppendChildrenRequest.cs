using System.Collections.Generic;

namespace Notion.Client
{
    public class BlockAppendChildrenRequest : IBlockAppendChildrenBodyParameters, IBlockAppendChildrenPathParameters
    {
        public IEnumerable<IBlockObjectRequest> Children { get; set; }

        public string After { get; set; }

        public string BlockId { get; set; }
    }
}
