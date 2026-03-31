using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPageCover
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
