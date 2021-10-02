using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitleProperty : Property
    {
        public override PropertyType Type => PropertyType.Title;

        [JsonProperty("title")]
        public Dictionary<string, object> Title { get; set; }
    }
}
