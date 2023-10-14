using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    // TODO: need an input version of Block
    public interface IBlockAppendChildrenBodyParameters
    {
        [JsonProperty("children")]
        IEnumerable<IBlock> Children { get; set; }

        /// <summary>
        ///     The ID of the existing block that the new block should be appended after.
        /// </summary>
        [JsonProperty("after")]
        public string After { get; set; }
    }

    internal class BlockAppendChildrenBodyParameters : IBlockAppendChildrenBodyParameters
    {
        public IEnumerable<IBlock> Children { get; set; }

        public string After { get; set; }

        public BlockAppendChildrenBodyParameters(BlockAppendChildrenRequest request)
        {
            Children = request.Children;
            After = request.After;
        }
    }
}
