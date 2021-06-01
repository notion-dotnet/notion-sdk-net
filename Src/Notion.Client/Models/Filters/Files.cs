using System;
using Newtonsoft.Json;

namespace Notion.Client
{

    public class FilesFilter : SinglePropertyFilter
    {
        public FilesFilterCondition Files { get; set; }
    }

    public class FilesFilterCondition
    {
        [JsonProperty("is_empty")]
        public Nullable<bool> IsEmpty { get; set; }

        [JsonProperty("is_not_empty")]
        public Nullable<bool> IsNotEmpty { get; set; }
    }
}