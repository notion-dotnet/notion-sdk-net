using System;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class ImageBlock : Block
    {
        public override BlockType Type => BlockType.Image;

        [JsonProperty("image")]
        public FileObject Image { get; set; }
    }

    public enum FileType
    {
        [EnumMember(Value = "external")]
        External,

        [EnumMember(Value = "file")]
        File
    }

    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UploadedFile), FileType.File)]
    [JsonSubtypes.KnownSubType(typeof(ExternalFile), FileType.External)]
    public abstract class FileObject
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual FileType Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class UploadedFile : FileObject
    {
        public override FileType Type => FileType.File;

        [JsonProperty("expiry_time")]
        public DateTime ExpiryTime { get; set; }
    }

    public class ExternalFile : FileObject
    {
        public override FileType Type => FileType.External;
    }
}
