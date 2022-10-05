using Newtonsoft.Json;

namespace Notion.Client
{
    internal class NotionApiErrorResponse
    {
        [JsonProperty("code")]
        public NotionAPIErrorCode ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
