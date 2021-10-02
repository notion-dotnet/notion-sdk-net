using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxPropertySchema : IPropertySchema
    {
        [JsonProperty("checkbox")]
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
