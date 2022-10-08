using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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
