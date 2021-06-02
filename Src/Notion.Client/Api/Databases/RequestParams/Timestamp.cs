using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum Timestamp
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime
    }
}
