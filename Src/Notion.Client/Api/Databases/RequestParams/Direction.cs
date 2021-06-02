using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum Direction
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "ascending")]
        Ascending,

        [EnumMember(Value = "descending")]
        Descending
    }
}
