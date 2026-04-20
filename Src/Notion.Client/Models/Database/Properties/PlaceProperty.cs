using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PlaceProperty : Property
    {
        public override PropertyType Type => PropertyType.Place;

        [JsonProperty("place")]
        public Dictionary<string, object> Place { get; set; }
    }
}
