using System;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UploadedFile), "file")]
    [JsonSubtypes.KnownSubType(typeof(ExternalFile), "external")]
    public abstract class FileObject : IPageIcon
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class UploadedFile : FileObject
    {
        public override string Type => "file";

        [JsonProperty("expiry_time")]
        public DateTime ExpiryTime { get; set; }
    }

    public class ExternalFile : FileObject
    {
        public override string Type => "external";
    }
}
