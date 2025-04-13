using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalFileInput : IFileObjectInput
    {
        [JsonProperty("external")]
        public Data External { get; set; }

        public string Name { get; set; }

        public IEnumerable<RichTextBaseInput> Caption { get; set; }

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
