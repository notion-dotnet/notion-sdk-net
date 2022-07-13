﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToDoUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBaseInput> Text { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }
        }
    }
}
