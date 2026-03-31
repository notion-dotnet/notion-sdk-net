using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IParentOfDatabaseRequest
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
