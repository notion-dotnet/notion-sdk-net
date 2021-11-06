using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IRetrievePropertyItemPathParameters
    {
        [JsonProperty("page_id")]
        string PageId { get; set; }

        [JsonProperty("property_id")]
        string PropertyId { get; set; }
    }
}
