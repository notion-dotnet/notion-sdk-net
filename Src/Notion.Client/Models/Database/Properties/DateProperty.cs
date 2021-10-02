using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DateProperty : Property
    {
        public override PropertyType Type => PropertyType.Date;

        [JsonProperty("date")]
        public Dictionary<string, object> Date { get; set; }
    }
}
