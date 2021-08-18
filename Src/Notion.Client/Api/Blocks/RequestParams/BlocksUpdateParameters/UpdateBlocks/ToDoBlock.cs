using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToDoUpdateBlock : IUpdateBlock
    {
        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBaseInput> Text { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }
        }
    }
}
