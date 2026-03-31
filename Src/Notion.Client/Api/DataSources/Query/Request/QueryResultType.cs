using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum QueryResultType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "page")]
        Page,

        [EnumMember(Value = "data_source")]
        DataSource
    }
}