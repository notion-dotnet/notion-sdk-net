using Newtonsoft.Json;

namespace Notion.Client
{
    public class ExternalPageCoverRequest : IPageCoverRequest
    {
        public string Type { get; set; } = PageCoverRequestTypes.External;

        [JsonProperty("external")]
        public Info External { get; set; }

        public class Info
        {
            /// <summary>
            /// The URL of the external file.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
