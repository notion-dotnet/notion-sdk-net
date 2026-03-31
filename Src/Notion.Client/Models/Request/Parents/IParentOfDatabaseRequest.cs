using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IParentOfPageRequest
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
