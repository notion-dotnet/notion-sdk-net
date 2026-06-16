using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreateViewQueryRequest
    {
        /// <summary>
        /// The ID of the view to query. This is a path parameter and is not serialized in the request body.
        /// </summary>
        [JsonIgnore]
        public string ViewId { get; set; }

        [JsonProperty("page_size")]
        public int? PageSize { get; set; }
    }
}
