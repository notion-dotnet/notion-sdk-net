using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPageCoverRequest
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
