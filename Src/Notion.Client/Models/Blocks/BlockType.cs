using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum BlockType
    {
        [EnumMember(Value = "paragraph")]
        Paragraph,

        [EnumMember(Value = "heading_1")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Heading_1,

        [EnumMember(Value = "heading_2")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Heading_2,

        [EnumMember(Value = "heading_3")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
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

        [EnumMember(Value = "code")]
        Code,

        [EnumMember(Value = "child_database")]
        ChildDatabase,

        [EnumMember(Value = "embed")]
        Embed,

        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "pdf")]
        PDF,

        [EnumMember(Value = "bookmark")]
        Bookmark,

        [EnumMember(Value = "equation")]
        Equation,

        [EnumMember(Value = "breadcrumb")]
        Breadcrumb,

        [EnumMember(Value = "divider")]
        Divider,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "table_of_contents")]
        TableOfContents,

        [EnumMember(Value = "callout")]
        Callout,

        [EnumMember(Value = "quote")]
        Quote,

        [EnumMember(Value = "column")]
        Column,

        [EnumMember(Value = "column_list")]
        ColumnList,

        [EnumMember(Value = "template")]
        Template,

        [EnumMember(Value = "link_to_page")]
        LinkToPage,

        [EnumMember(Value = "synced_block")]
        SyncedBlock,

        [EnumMember(Value = "table")]
        Table,

        [EnumMember(Value = "table_row")]
        TableRow,

        [EnumMember(Value = "link_preview")]
        LinkPreview,

        [EnumMember(Value = "unsupported")]
        Unsupported
    }
}
