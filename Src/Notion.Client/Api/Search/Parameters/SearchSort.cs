using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchSort
    {
        public SearchDirection Direction { get; set; }

        public string Timestamp { get; set; }
    }
}
