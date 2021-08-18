using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByPropertySchema : IPropertySchema
    {
        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }
}
