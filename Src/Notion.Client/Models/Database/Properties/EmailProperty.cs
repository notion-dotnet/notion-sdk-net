using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailProperty : Property
    {
        public override PropertyType Type => PropertyType.Email;

        [JsonProperty("email")]
        public Dictionary<string, object> Email { get; set; }
    }
}
