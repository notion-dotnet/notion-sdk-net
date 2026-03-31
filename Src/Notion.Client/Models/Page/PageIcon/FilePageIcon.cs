using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilePageIcon : IPageIcon
    {
        public string Type { get; set; } = PageIconTypes.File;

        [JsonProperty(PageIconTypes.File)]
        public InternalFileInfo File { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
