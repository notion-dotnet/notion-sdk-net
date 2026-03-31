using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.PhoneNumber;

        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }
}
