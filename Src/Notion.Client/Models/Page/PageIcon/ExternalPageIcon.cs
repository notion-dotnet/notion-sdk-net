using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalPageIcon : IPageIcon
    {
        public string Type { get; set; } = PageIconTypes.External;

        [JsonProperty(PageIconTypes.External)]
        public ExternalFileInfo External { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
