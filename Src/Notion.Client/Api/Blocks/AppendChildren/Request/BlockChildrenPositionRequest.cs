using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IBlockChildrenPositionRequest
    {
        [JsonProperty("type")]
        string Type { get; }
    }

    public class StartBlockChildrenPositionRequest : IBlockChildrenPositionRequest
    {
        public string Type => "start";
    }

    public class EndBlockChildrenPositionRequest : IBlockChildrenPositionRequest
    {
        public string Type => "end";
    }

    public class AfterBlockChildrenPositionRequest : IBlockChildrenPositionRequest
    {
        public string Type => "after_block";

        [JsonProperty("after_block")]
        public BlockChildrenPositionReference AfterBlock { get; set; }
    }

    public class BlockChildrenPositionReference
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
