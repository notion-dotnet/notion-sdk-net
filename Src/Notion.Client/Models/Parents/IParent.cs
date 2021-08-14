using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public interface IParent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        ParentType Type { get; set; }
    }
}
