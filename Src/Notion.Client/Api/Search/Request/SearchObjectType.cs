using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum SearchObjectType
    {
        [EnumMember(Value = "page")]
        Page,

        [EnumMember(Value = "data_source")]
        DataSource
    }
}
