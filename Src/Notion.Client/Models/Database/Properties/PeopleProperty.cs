using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeopleProperty : Property
    {
        public override PropertyType Type => PropertyType.People;

        [JsonProperty("people")]
        public Dictionary<string, object> People { get; set; }
    }
}
