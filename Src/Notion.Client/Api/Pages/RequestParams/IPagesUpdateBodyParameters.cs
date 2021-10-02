using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesUpdateBodyParameters
    {
        [JsonProperty("archived")]
        bool Archived { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
