using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum RichTextType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "mention")]
        Mention,

        [EnumMember(Value = "equation")]
        Equation,
    }
}
