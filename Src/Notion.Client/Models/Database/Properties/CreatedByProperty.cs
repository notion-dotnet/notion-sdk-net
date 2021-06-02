using Newtonsoft.Json;
using System.Collections.Generic;

namespace Notion.Client
{
    public class CreatedByProperty : Property
    {
        public override PropertyType Type => PropertyType.CreatedBy;

        [JsonProperty("created_by")]
        public Dictionary<string, object> CreatedBy { get; set; }
    }
}
