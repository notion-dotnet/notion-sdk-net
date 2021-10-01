using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalFileWithName : FileObjectWithName
    {
        public override string Type => "external";

        [JsonProperty("external")]
        public Info External { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
