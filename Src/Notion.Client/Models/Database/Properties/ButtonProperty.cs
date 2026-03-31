using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ButtonProperty : Property
    {
        public override PropertyType Type => PropertyType.Button;

        [JsonProperty("button")]
        public Dictionary<string,object> Button { get; set; }
    }
}
