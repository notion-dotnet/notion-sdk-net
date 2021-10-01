using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UploadedFile), "file")]
    [JsonSubtypes.KnownSubType(typeof(ExternalFile), "external")]
    public abstract class FileObject : IPageIcon
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }
}
