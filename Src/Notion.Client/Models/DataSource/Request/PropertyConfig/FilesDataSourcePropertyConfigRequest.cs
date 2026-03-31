using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "files";

        [JsonProperty("files")]
        public IDictionary<string, object> Files { get; set; }
    }
}