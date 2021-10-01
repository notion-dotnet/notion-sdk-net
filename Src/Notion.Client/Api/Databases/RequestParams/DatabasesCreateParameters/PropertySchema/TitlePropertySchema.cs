using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitlePropertySchema : IPropertySchema
    {
        [JsonProperty("title")]
        public Dictionary<string, object> Title { get; set; }
    }
}
