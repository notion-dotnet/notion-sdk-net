using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxProperty : Property
    {
        public override PropertyType Type => PropertyType.Checkbox;

        [JsonProperty("checkbox")]
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
