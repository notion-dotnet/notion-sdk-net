using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPageIcon
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
