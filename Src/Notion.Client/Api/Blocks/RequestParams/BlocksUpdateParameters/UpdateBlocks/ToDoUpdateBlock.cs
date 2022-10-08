using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToDoUpdateBlock : UpdateBlock
    {
        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }
        }
    }
}
