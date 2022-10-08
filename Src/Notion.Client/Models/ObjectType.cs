using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum ObjectType
    {
        [EnumMember(Value = "page")]
        Page,

        [EnumMember(Value = "database")]
        Database,

        [EnumMember(Value = "block")]
        Block,

        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "comment")]
        Comment
    }
}
