using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TextContentUpdate
    {
        [JsonProperty("text")]
        public IEnumerable<RichTextBaseInput> Text { get; set; }
    }
}
