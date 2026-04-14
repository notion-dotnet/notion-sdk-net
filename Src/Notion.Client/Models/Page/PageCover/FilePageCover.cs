using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilePageCover : IPageCover
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "file";

        [JsonProperty("file")]
        public InternalFileInfo File { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
