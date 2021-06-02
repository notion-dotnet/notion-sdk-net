using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum BlockType
    {
        [EnumMember(Value = "paragraph")]
        Paragraph,

        [EnumMember(Value = "heading_1")]
        Heading_1,

        [EnumMember(Value = "heading_2")]
        Heading_2,

        [EnumMember(Value = "heading_3")]
        Heading_3,

        [EnumMember(Value = "bulleted_list_item")]
        BulletedListItem,

        [EnumMember(Value = "numbered_list_item")]
        NumberedListItem,

        [EnumMember(Value = "to_do")]
        ToDo,

        [EnumMember(Value = "toggle")]
        Toggle,

        [EnumMember(Value = "child_page")]
        ChildPage,

        [EnumMember(Value = "unsupported")]
        Unsupported
    }
}