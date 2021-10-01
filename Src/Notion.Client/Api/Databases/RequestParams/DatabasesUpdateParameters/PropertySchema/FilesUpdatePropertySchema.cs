using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("files")]
        public Dictionary<string, object> Files { get; set; }
    }
}
