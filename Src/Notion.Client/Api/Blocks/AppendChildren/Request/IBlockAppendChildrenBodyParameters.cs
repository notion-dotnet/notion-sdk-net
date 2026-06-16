using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IBlockAppendChildrenBodyParameters
    {
        [JsonProperty("children")]
        IEnumerable<IBlockObjectRequest> Children { get; set; }

        /// <summary>
        ///     Controls where the new blocks are placed within the parent.
        ///     Supports <see cref="AfterBlockContentPosition"/>, <see cref="StartContentPosition"/>,
        ///     and <see cref="EndContentPosition"/>. Defaults to end when omitted.
        /// </summary>
        [JsonProperty("position")]
        ContentPosition Position { get; set; }
    }

    internal class BlockAppendChildrenBodyParameters : IBlockAppendChildrenBodyParameters
    {
        public IEnumerable<IBlockObjectRequest> Children { get; set; }

        public ContentPosition Position { get; set; }

        public BlockAppendChildrenBodyParameters(BlockAppendChildrenRequest request)
        {
            Children = request.Children;
            Position = request.Position;
        }
    }
}
