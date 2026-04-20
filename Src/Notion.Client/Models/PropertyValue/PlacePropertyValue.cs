using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PlacePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Place;

        [JsonProperty("place")]
        public PlaceInfo Place { get; set; }

        public class PlaceInfo
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lon")]
            public double Lon { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("aws_place_id")]
            public string AwsPlaceId { get; set; }

            [JsonProperty("google_place_id")]
            public string GooglePlaceId { get; set; }
        }
    }
}
