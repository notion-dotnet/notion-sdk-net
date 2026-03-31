using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "last_edited_by";

        [JsonProperty("last_edited_by")]
        public IDictionary<string, object> LastEditedBy { get; set; }
    }
}