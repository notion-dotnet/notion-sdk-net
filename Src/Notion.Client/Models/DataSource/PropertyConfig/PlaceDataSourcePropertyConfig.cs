using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PlaceDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Place;

        [JsonProperty("place")]
        public Dictionary<string, object> Place { get; set; }
    }
}
