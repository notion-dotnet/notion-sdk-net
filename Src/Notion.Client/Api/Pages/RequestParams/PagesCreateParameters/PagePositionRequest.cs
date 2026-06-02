using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagePositionRequest
    {
        [JsonProperty("type")]
        string Type { get; }
    }

    public class PageStartPositionRequest : IPagePositionRequest
    {
        public string Type => "page_start";
    }

    public class PageEndPositionRequest : IPagePositionRequest
    {
        public string Type => "page_end";
    }

    public class AfterBlockPagePositionRequest : IPagePositionRequest
    {
        public string Type => "after_block";

        [JsonProperty("after_block")]
        public AfterBlockReference AfterBlock { get; set; }
    }

    public class AfterBlockReference
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
