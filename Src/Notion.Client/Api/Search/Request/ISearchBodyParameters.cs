using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ISearchBodyParameters : IPaginationParameters
    {
        [JsonProperty("query")]
        string Query { get; set; }

        [JsonProperty("sort")]
        SearchSort Sort { get; set; }

        [JsonProperty("filter")]
        SearchFilter Filter { get; set; }
    }
}
