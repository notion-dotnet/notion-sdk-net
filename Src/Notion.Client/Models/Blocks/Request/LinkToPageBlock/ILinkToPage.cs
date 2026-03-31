using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(LinkPageToPage), "page_id")]
    [JsonSubtypes.KnownSubType(typeof(LinkDatabaseToPage), "database_id")]
    [JsonSubtypes.KnownSubType(typeof(LinkCommentToPage), "comment_id")]
    public interface ILinkToPage
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
