using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPagesUpdateBodyParameters
    {
        [JsonProperty("in_trash")]
        bool InTrash { get; set; }

        [JsonProperty("properties")]
        IDictionary<string, PropertyValue> Properties { get; set; }
    }
}
