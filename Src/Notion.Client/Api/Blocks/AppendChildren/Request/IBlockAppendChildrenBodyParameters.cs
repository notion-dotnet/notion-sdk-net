using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IBlockAppendChildrenBodyParameters
    {
        [JsonProperty("children")]
        IEnumerable<IBlockObjectRequest> Children { get; set; }

        /// <summary>
        ///     The ID of the existing block that the new block should be appended after.
        /// </summary>
        [JsonProperty("after")]
        public string After { get; set; }
    }

    internal class BlockAppendChildrenBodyParameters : IBlockAppendChildrenBodyParameters
    {
        public IEnumerable<IBlockObjectRequest> Children { get; set; }

        public string After { get; set; }

        public BlockAppendChildrenBodyParameters(BlockAppendChildrenRequest request)
        {
            Children = request.Children;
            After = request.After;
        }
    }
}
