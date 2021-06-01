using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesFilter : SinglePropertyFilter
    {
        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}