using System;
using Newtonsoft.Json;

namespace Notion.Client
{

    public class FilesFilter : SinglePropertyFilter
    {
        public Condition Files { get; set; }

        public class Condition
        {
            [JsonProperty("is_empty")]
            public Nullable<bool> IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public Nullable<bool> IsNotEmpty { get; set; }
        }
    }
}