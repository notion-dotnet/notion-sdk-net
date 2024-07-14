using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Notion.Client
{
    public class ButtonProperty : Property
    {
        public override PropertyType Type => PropertyType.Button;

        [JsonProperty("button")]
        public Dictionary<string,object> Button { get; set; }
    }
}
