using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IFileObjectInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("caption")]
        public IEnumerable<RichTextBaseInput> Caption { get; set; }
    }
}
