using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UploadedFile), "file")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ExternalFile), "external")]
    public abstract class FileObject
    {
        [JsonProperty("caption")]
        public IEnumerable<RichTextBase> Caption { get; set; }

        /// <summary>
        /// The name of the file block, as shown in the Notion UI. Note that the UI may auto-append .pdf or other extensions.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }
}
