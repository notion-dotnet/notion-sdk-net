using System.Collections.Generic;

namespace Notion.Client
{
    public class BlockAppendChildrenRequest : IBlockAppendChildrenBodyParameters, IBlockAppendChildrenPathParameters
    {
        public IEnumerable<IBlockObjectRequest> Children { get; set; }

        /// <summary>
        ///     Controls where the new blocks are placed within the parent.
        ///     Use <see cref="AfterBlockContentPosition"/>, <see cref="StartContentPosition"/>,
        ///     or <see cref="EndContentPosition"/>. Defaults to end when omitted.
        /// </summary>
        public ContentPosition Position { get; set; }

        public string BlockId { get; set; }
    }
}
