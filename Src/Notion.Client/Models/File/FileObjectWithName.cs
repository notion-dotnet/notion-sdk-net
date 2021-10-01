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
}
