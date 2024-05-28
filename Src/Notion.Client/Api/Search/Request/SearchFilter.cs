using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SearchFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchObjectType Value { get; set; }

        public string Property => "object";
    }
}
