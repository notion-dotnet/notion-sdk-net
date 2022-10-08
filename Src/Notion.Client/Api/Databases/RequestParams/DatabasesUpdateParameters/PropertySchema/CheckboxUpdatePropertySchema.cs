using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("checkbox")]
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
