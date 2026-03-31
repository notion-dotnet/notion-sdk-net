using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.LastEditedBy;

        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }
}
