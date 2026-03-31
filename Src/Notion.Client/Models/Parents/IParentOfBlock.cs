using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(DatabaseParent), ParentTypes.Database)]
    [JsonSubtypes.KnownSubType(typeof(DatasourceParent), ParentTypes.Datasource)]
    [JsonSubtypes.KnownSubType(typeof(PageParent), ParentTypes.Page)]
    [JsonSubtypes.KnownSubType(typeof(BlockParent), ParentTypes.Block)]
    [JsonSubtypes.KnownSubType(typeof(WorkspaceParent), ParentTypes.Workspace)]
    public interface IParentOfBlock
    {
        [JsonProperty("type")]
        string Type { get; set; }
    }
}
