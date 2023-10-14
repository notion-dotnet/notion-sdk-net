using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class ToDoBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public override BlockType Type => BlockType.ToDo;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }

            [JsonProperty("color")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }
        }
    }
}
