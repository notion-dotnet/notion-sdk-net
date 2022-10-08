using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }
}
