using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IRetrieveCommentsQueryParameters : IPaginationParameters
    {
        [JsonProperty("block_id")]
        string BlockId { get; set; }
    }
}
