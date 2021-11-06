using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesPropertyItem : SimplePropertyItem
    {
        public override string Type => "files";

        [JsonProperty("files")]
        public IEnumerable<FileObjectWithName> Files { get; set; }
    }
}
