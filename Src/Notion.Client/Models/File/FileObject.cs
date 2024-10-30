using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UploadedFile), "file")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ExternalFile), "external")]
    public abstract class FileObject : IPageIcon
    {
        [JsonProperty("caption")]
        public IEnumerable<RichTextBase> Caption { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }
}
