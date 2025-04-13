using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UploadedFileInput : IFileObjectInput
    {
        [JsonProperty("file")]
        public Data File { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("caption")]
        public IEnumerable<RichTextBaseInput> Caption { get; set; }

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("expiry_time")]
            public DateTime ExpiryTime { get; set; }
        }
    }
}
