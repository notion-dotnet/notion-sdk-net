using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesProperty : Property
    {
        public override PropertyType Type => PropertyType.Files;

        [JsonProperty("files")]
        public Dictionary<string, object> Files { get; set; }
    }
}
