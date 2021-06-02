using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByProperty : Property
    {
        public override PropertyType Type => PropertyType.LastEditedBy;

        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }
}
