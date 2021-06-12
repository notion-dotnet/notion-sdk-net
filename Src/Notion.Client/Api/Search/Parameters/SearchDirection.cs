using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum SearchDirection
    {
        [EnumMember(Value = "ascending")]
        Ascending,

        [EnumMember(Value = "descending")]
        Descending
    }
}
