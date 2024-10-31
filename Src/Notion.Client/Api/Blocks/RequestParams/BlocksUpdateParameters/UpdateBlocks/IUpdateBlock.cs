using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IUpdateBlock
    {
        [JsonProperty("in_trash")]
        bool InTrash { get; set; }
    }
}
