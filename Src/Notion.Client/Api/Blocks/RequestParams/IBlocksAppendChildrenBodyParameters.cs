using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    // TODO: need an input version of Block
    public interface IBlocksAppendChildrenBodyParameters
    {
        [JsonProperty("children")]
        IEnumerable<Block> Children { get; set; }
    }
}
