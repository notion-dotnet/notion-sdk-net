using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(AudioBlock), BlockType.Audio)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BookmarkBlock), BlockType.Bookmark)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BreadcrumbBlock), BlockType.Breadcrumb)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(BulletedListItemBlock), BlockType.BulletedListItem)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CalloutBlock), BlockType.Callout)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ChildPageBlock), BlockType.ChildPage)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ChildDatabaseBlock), BlockType.ChildDatabase)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CodeBlock), BlockType.Code)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ColumnBlock), BlockType.Column)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ColumnListBlock), BlockType.ColumnList)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DividerBlock), BlockType.Divider)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmbedBlock), BlockType.Embed)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EquationBlock), BlockType.Equation)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FileBlock), BlockType.File)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingOneBlock), BlockType.Heading_1)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingTwoBlock), BlockType.Heading_2)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(HeadingThreeBlock), BlockType.Heading_3)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ImageBlock), BlockType.Image)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LinkPreviewBlock), BlockType.LinkPreview)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LinkToPageBlock), BlockType.LinkToPage)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberedListItemBlock), BlockType.NumberedListItem)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ParagraphBlock), BlockType.Paragraph)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PDFBlock), BlockType.PDF)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(QuoteBlock), BlockType.Quote)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SyncedBlockBlock), BlockType.SyncedBlock)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableBlock), BlockType.Table)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableRowBlock), BlockType.TableRow)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TableOfContentsBlock), BlockType.TableOfContents)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TemplateBlock), BlockType.Template)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ToDoBlock), BlockType.ToDo)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ToggleBlock), BlockType.Toggle)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(VideoBlock), BlockType.Video)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UnsupportedBlock), BlockType.Unsupported)]
    public interface IBlock : IObject, IObjectModificationData
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        BlockType Type { get; set; }

        [JsonProperty("has_children")]
        bool HasChildren { get; set; }

        [JsonProperty("in_trash")]
        bool InTrash { get; set; }

        [JsonProperty("parent")]
        IBlockParent Parent { get; set; }
    }
}
