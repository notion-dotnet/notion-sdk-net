using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UploadedFile : FileObject
    {
        public override string Type => "file";

        [JsonProperty("file")]
        public Info File { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("expiry_time")]
            public DateTime ExpiryTime { get; set; }
        }
    }
}
