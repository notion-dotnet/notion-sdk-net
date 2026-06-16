using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Represents the type of a Notion block.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// Use the <c>const string</c> members (e.g. <see cref="ParagraphValue"/>) when referencing a value
    /// in a <c>[JsonSubtypes.KnownSubType]</c> attribute; use the <c>static readonly</c> fields
    /// (e.g. <see cref="Paragraph"/>) everywhere else.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<BlockType>))]
    public readonly struct BlockType : IEquatable<BlockType>
    {
        private readonly string _value;

        public BlockType(string value) => _value = value;

        public const string ParagraphValue = "paragraph";
        public const string Heading1Value = "heading_1";
        public const string Heading2Value = "heading_2";
        public const string Heading3Value = "heading_3";
        public const string Heading4Value = "heading_4";
        public const string BulletedListItemValue = "bulleted_list_item";
        public const string NumberedListItemValue = "numbered_list_item";
        public const string ToDoValue = "to_do";
        public const string ToggleValue = "toggle";
        public const string ChildPageValue = "child_page";
        public const string CodeValue = "code";
        public const string ChildDatabaseValue = "child_database";
        public const string EmbedValue = "embed";
        public const string ImageValue = "image";
        public const string VideoValue = "video";
        public const string FileValue = "file";
        public const string PDFValue = "pdf";
        public const string BookmarkValue = "bookmark";
        public const string EquationValue = "equation";
        public const string BreadcrumbValue = "breadcrumb";
        public const string DividerValue = "divider";
        public const string AudioValue = "audio";
        public const string TableOfContentsValue = "table_of_contents";
        public const string CalloutValue = "callout";
        public const string QuoteValue = "quote";
        public const string ColumnValue = "column";
        public const string ColumnListValue = "column_list";
        public const string TemplateValue = "template";
        public const string LinkToPageValue = "link_to_page";
        public const string SyncedBlockValue = "synced_block";
        public const string TableValue = "table";
        public const string TableRowValue = "table_row";
        public const string LinkPreviewValue = "link_preview";
        public const string UnsupportedValue = "unsupported";

        [Obsolete("Use MeetingNotesValue instead. 'transcription' was renamed to 'meeting_notes' in Notion API version 2026-03-11.")]
        public const string TranscriptionValue = "transcription";
        public const string MeetingNotesValue = "meeting_notes";
        public const string TabValue = "tab";

        public static readonly BlockType Paragraph = new BlockType(ParagraphValue);
        public static readonly BlockType Heading1 = new BlockType(Heading1Value);
        public static readonly BlockType Heading2 = new BlockType(Heading2Value);
        public static readonly BlockType Heading3 = new BlockType(Heading3Value);
        public static readonly BlockType Heading4 = new BlockType(Heading4Value);
        public static readonly BlockType BulletedListItem = new BlockType(BulletedListItemValue);
        public static readonly BlockType NumberedListItem = new BlockType(NumberedListItemValue);
        public static readonly BlockType ToDo = new BlockType(ToDoValue);
        public static readonly BlockType Toggle = new BlockType(ToggleValue);
        public static readonly BlockType ChildPage = new BlockType(ChildPageValue);
        public static readonly BlockType Code = new BlockType(CodeValue);
        public static readonly BlockType ChildDatabase = new BlockType(ChildDatabaseValue);
        public static readonly BlockType Embed = new BlockType(EmbedValue);
        public static readonly BlockType Image = new BlockType(ImageValue);
        public static readonly BlockType Video = new BlockType(VideoValue);
        public static readonly BlockType File = new BlockType(FileValue);
        public static readonly BlockType PDF = new BlockType(PDFValue);
        public static readonly BlockType Bookmark = new BlockType(BookmarkValue);
        public static readonly BlockType Equation = new BlockType(EquationValue);
        public static readonly BlockType Breadcrumb = new BlockType(BreadcrumbValue);
        public static readonly BlockType Divider = new BlockType(DividerValue);
        public static readonly BlockType Audio = new BlockType(AudioValue);
        public static readonly BlockType TableOfContents = new BlockType(TableOfContentsValue);
        public static readonly BlockType Callout = new BlockType(CalloutValue);
        public static readonly BlockType Quote = new BlockType(QuoteValue);
        public static readonly BlockType Column = new BlockType(ColumnValue);
        public static readonly BlockType ColumnList = new BlockType(ColumnListValue);
        public static readonly BlockType Template = new BlockType(TemplateValue);
        public static readonly BlockType LinkToPage = new BlockType(LinkToPageValue);
        public static readonly BlockType SyncedBlock = new BlockType(SyncedBlockValue);
        public static readonly BlockType Table = new BlockType(TableValue);
        public static readonly BlockType TableRow = new BlockType(TableRowValue);
        public static readonly BlockType LinkPreview = new BlockType(LinkPreviewValue);
        public static readonly BlockType Unsupported = new BlockType(UnsupportedValue);

        [Obsolete("Use MeetingNotes instead. 'transcription' was renamed to 'meeting_notes' in Notion API version 2026-03-11.")]
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static readonly BlockType Transcription = new BlockType(TranscriptionValue);
        public static readonly BlockType MeetingNotes = new BlockType(MeetingNotesValue);
        public static readonly BlockType Tab = new BlockType(TabValue);

        public static implicit operator BlockType(string value) => new BlockType(value);

        public static bool operator ==(BlockType left, BlockType right) => left.Equals(right);
        public static bool operator !=(BlockType left, BlockType right) => !left.Equals(right);

        public bool Equals(BlockType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is BlockType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
