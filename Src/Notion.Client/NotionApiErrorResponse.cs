using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    internal class NotionApiErrorResponse
    {
        [JsonProperty("code")]
        public NotionAPIErrorCode ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("additional_data")]
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}
