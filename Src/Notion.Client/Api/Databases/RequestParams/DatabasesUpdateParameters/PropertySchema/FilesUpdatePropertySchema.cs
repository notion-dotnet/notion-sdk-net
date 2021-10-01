using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("file")]
        public Dictionary<string, object> File { get; set; }
    }
}
