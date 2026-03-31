using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreateCommentsBodyParameters
    {
        [JsonProperty("rich_text")]
        public IEnumerable<RichTextBaseInput> RichText { get; set; }
    }
}
