using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum ParentType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "database_id")]
        DatabaseId,

        [EnumMember(Value = "page_id")]
        PageId,
        [EnumMember(Value = "workspace")]
        Workspace
    }
}
