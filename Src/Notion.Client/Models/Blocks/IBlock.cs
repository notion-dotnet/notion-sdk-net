using System;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(AudioBlock), BlockType.AudioValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BookmarkBlock), BlockType.BookmarkValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BreadcrumbBlock), BlockType.BreadcrumbValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BulletedListItemBlock), BlockType.BulletedListItemValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CalloutBlock), BlockType.CalloutValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ChildPageBlock), BlockType.ChildPageValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ChildDatabaseBlock), BlockType.ChildDatabaseValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CodeBlock), BlockType.CodeValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ColumnBlock), BlockType.ColumnValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ColumnListBlock), BlockType.ColumnListValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DividerBlock), BlockType.DividerValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmbedBlock), BlockType.EmbedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EquationBlock), BlockType.EquationValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileBlock), BlockType.FileValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingOneBlock), BlockType.Heading1Value)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingTwoBlock), BlockType.Heading2Value)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingThreeBlock), BlockType.Heading3Value)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ImageBlock), BlockType.ImageValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LinkPreviewBlock), BlockType.LinkPreviewValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LinkToPageBlock), BlockType.LinkToPageValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberedListItemBlock), BlockType.NumberedListItemValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ParagraphBlock), BlockType.ParagraphValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PDFBlock), BlockType.PDFValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(QuoteBlock), BlockType.QuoteValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SyncedBlockBlock), BlockType.SyncedBlockValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableBlock), BlockType.TableValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableRowBlock), BlockType.TableRowValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableOfContentsBlock), BlockType.TableOfContentsValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TemplateBlock), BlockType.TemplateValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ToDoBlock), BlockType.ToDoValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ToggleBlock), BlockType.ToggleValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(VideoBlock), BlockType.VideoValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TabBlock), BlockType.TabValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UnsupportedBlock), BlockType.UnsupportedValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MeetingNotesBlock), BlockType.MeetingNotesValue)]
#pragma warning disable CS0618
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TranscriptionBlock), "transcription")]
#pragma warning restore CS0618
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(UnsupportedBlock))]
    public interface IBlock : IObject, IObjectModificationData
    {
        [JsonProperty("type")]
        BlockType Type { get; set; }

        [JsonProperty("has_children")]
        bool HasChildren { get; set; }

        [JsonProperty("in_trash")]
        bool InTrash { get; set; }

        [JsonProperty("parent")]
        IParentOfBlock Parent { get; set; }
    }
}
