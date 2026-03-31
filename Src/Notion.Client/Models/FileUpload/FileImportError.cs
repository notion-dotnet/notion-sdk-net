using Newtonsoft.Json;

namespace Notion.Client
{
    public class FileImportError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("status_code")]
        public int? StatusCode { get; set; }
    }
}
