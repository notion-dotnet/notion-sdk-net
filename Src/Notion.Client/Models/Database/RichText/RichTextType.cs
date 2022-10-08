using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum RichTextType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "mention")]
        Mention,

        [EnumMember(Value = "equation")]
        Equation
    }
}
