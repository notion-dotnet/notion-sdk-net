using System;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UploadedFileWithName), "file")]
    [JsonSubtypes.KnownSubType(typeof(ExternalFileWithName), "external")]
    public abstract class FileObjectWithName
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class UploadedFileWithName : FileObjectWithName
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

    public class ExternalFileWithName : FileObjectWithName
    {
        public override string Type => "external";

        [JsonProperty("external")]
        public Info External { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
