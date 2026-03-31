using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Files;

        [JsonProperty("files")]
        public Dictionary<string, object> Files { get; set; }
    }
}
