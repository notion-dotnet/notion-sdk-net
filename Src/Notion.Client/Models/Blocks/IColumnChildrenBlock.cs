using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    //[JsonConverter(typeof(JsonSubtypes), "type")]
    //[JsonSubtypes.KnownSubType(typeof(AudioBlock), BlockType.Audio)]
    //[JsonSubtypes.KnownSubType(typeof(BookmarkBlock), BlockType.Bookmark)]
    //[JsonSubtypes.KnownSubType(typeof(BreadcrumbBlock), BlockType.Breadcrumb)]
    //[JsonSubtypes.KnownSubType(typeof(BulletedListItemBlock), BlockType.BulletedListItem)]
    //[JsonSubtypes.KnownSubType(typeof(CalloutBlock), BlockType.Callout)]
    //[JsonSubtypes.KnownSubType(typeof(ChildDatabaseBlock), BlockType.ChildDatabase)]
    //[JsonSubtypes.KnownSubType(typeof(ChildPageBlock), BlockType.ChildPage)]
    //[JsonSubtypes.KnownSubType(typeof(CodeBlock), BlockType.Code)]
    //[JsonSubtypes.KnownSubType(typeof(DividerBlock), BlockType.Divider)]
    //[JsonSubtypes.KnownSubType(typeof(EmbedBlock), BlockType.Embed)]
    //[JsonSubtypes.KnownSubType(typeof(EquationBlock), BlockType.Equation)]
    //[JsonSubtypes.KnownSubType(typeof(FileBlock), BlockType.File)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingOneBlock), BlockType.Heading_1)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingTwoBlock), BlockType.Heading_2)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingThreeeBlock), BlockType.Heading_3)]
    //[JsonSubtypes.KnownSubType(typeof(ImageBlock), BlockType.Image)]
    //[JsonSubtypes.KnownSubType(typeof(NumberedListItemBlock), BlockType.NumberedListItem)]
    //[JsonSubtypes.KnownSubType(typeof(ParagraphBlock), BlockType.Paragraph)]
    //[JsonSubtypes.KnownSubType(typeof(PDFBlock), BlockType.PDF)]
    //[JsonSubtypes.KnownSubType(typeof(QuoteBlock), BlockType.Quote)]
    //[JsonSubtypes.KnownSubType(typeof(TableOfContentsBlock), BlockType.TableOfContents)]
    //[JsonSubtypes.KnownSubType(typeof(ToDoBlock), BlockType.ToDo)]
    //[JsonSubtypes.KnownSubType(typeof(ToggleBlock), BlockType.Toggle)]
    //[JsonSubtypes.KnownSubType(typeof(VideoBlock), BlockType.Video)]
    //[JsonSubtypes.KnownSubType(typeof(UnsupportedBlock), BlockType.Unsupported)]
    public interface IColumnChildrenBlock : IBlock
    {
    }

    //[JsonConverter(typeof(JsonSubtypes), "type")]
    //[JsonSubtypes.KnownSubType(typeof(AudioBlock), BlockType.Audio)]
    //[JsonSubtypes.KnownSubType(typeof(BookmarkBlock), BlockType.Bookmark)]
    //[JsonSubtypes.KnownSubType(typeof(BreadcrumbBlock), BlockType.Breadcrumb)]
    //[JsonSubtypes.KnownSubType(typeof(BulletedListItemBlock), BlockType.BulletedListItem)]
    //[JsonSubtypes.KnownSubType(typeof(CalloutBlock), BlockType.Callout)]
    //[JsonSubtypes.KnownSubType(typeof(ChildPageBlock), BlockType.ChildPage)]
    //[JsonSubtypes.KnownSubType(typeof(ChildDatabaseBlock), BlockType.ChildDatabase)]
    //[JsonSubtypes.KnownSubType(typeof(CodeBlock), BlockType.Code)]
    //[JsonSubtypes.KnownSubType(typeof(ColumnListBlock), BlockType.ColumnList)]
    //[JsonSubtypes.KnownSubType(typeof(DividerBlock), BlockType.Divider)]
    //[JsonSubtypes.KnownSubType(typeof(EmbedBlock), BlockType.Embed)]
    //[JsonSubtypes.KnownSubType(typeof(EquationBlock), BlockType.Equation)]
    //[JsonSubtypes.KnownSubType(typeof(FileBlock), BlockType.File)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingOneBlock), BlockType.Heading_1)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingTwoBlock), BlockType.Heading_2)]
    //[JsonSubtypes.KnownSubType(typeof(HeadingThreeeBlock), BlockType.Heading_3)]
    //[JsonSubtypes.KnownSubType(typeof(ImageBlock), BlockType.Image)]
    //[JsonSubtypes.KnownSubType(typeof(NumberedListItemBlock), BlockType.NumberedListItem)]
    //[JsonSubtypes.KnownSubType(typeof(ParagraphBlock), BlockType.Paragraph)]
    //[JsonSubtypes.KnownSubType(typeof(PDFBlock), BlockType.PDF)]
    //[JsonSubtypes.KnownSubType(typeof(QuoteBlock), BlockType.Quote)]
    //[JsonSubtypes.KnownSubType(typeof(TableOfContentsBlock), BlockType.TableOfContents)]
    //[JsonSubtypes.KnownSubType(typeof(ToDoBlock), BlockType.ToDo)]
    //[JsonSubtypes.KnownSubType(typeof(ToggleBlock), BlockType.Toggle)]
    //[JsonSubtypes.KnownSubType(typeof(VideoBlock), BlockType.Video)]
    //[JsonSubtypes.KnownSubType(typeof(UnsupportedBlock), BlockType.Unsupported)]
    public interface INonColumnBlock : IBlock
    {
    }
}
