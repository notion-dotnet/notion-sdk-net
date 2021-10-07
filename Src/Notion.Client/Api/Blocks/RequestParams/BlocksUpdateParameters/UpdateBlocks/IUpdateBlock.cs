using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IUpdateBlock
    {
        [JsonProperty("archived")]
        bool Archived { get; set; }
    }
}
