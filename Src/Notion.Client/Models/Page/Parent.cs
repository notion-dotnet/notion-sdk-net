using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(DatabaseParent), ParentType.DatabaseId)]
    [JsonSubtypes.KnownSubType(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubType(typeof(WorkspaceParent), ParentType.Workspace)]
    public class Parent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ParentType Type { get; set; }
    }
}
