using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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
