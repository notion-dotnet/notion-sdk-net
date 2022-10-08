using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum RelationType
    {
        [EnumMember(Value = "single_property")]
        Single,

        [EnumMember(Value = "dual_property")]
        Dual
    }
}
