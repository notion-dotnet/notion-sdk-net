using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UploadedFileInput : IFileObjectInput
    {
        [JsonProperty("file")]
        public Data File { get; set; }

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("expiry_time")]
            public DateTime ExpiryTime { get; set; }
        }
    }
}
