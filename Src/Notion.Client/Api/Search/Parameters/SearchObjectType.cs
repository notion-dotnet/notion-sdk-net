using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum SearchObjectType
    {
        [EnumMember(Value = "page")]
        Page,

        [EnumMember(Value = "database")]
        Database
    }
}
