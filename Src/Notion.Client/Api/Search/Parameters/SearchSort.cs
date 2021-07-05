using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchSort
    {
        public SearchDirection Direction { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
