using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IParent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        ParentType Type { get; set; }
    }
}
