using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum ParentType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "database_id")]
        DatabaseId,

        [EnumMember(Value = "page_id")]
        PageId,

        [EnumMember(Value = "workspace")]
        Workspace,

        [EnumMember(Value = "block_id")]
        BlockId
    }
}
