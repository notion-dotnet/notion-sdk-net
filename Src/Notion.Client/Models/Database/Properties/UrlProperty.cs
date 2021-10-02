using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UrlProperty : Property
    {
        public override PropertyType Type => PropertyType.Url;

        [JsonProperty("url")]
        public Dictionary<string, object> Url { get; set; }
    }
}
