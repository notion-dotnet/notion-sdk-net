using System.Collections.Generic;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(BulletedListItemBlock), BlockType.BulletedListItem)]
    [JsonSubtypes.KnownSubType(typeof(ChildPageBlock), BlockType.ChildPage)]
    [JsonSubtypes.KnownSubType(typeof(HeadingOneBlock), BlockType.Heading_1)]
    [JsonSubtypes.KnownSubType(typeof(HeadingTwoBlock), BlockType.Heading_2)]
    [JsonSubtypes.KnownSubType(typeof(HeadingThreeeBlock), BlockType.Heading_3)]
    [JsonSubtypes.KnownSubType(typeof(NumberedListItemBlock), BlockType.NumberedListItem)]
    [JsonSubtypes.KnownSubType(typeof(ParagraphBlock), BlockType.Paragraph)]
    [JsonSubtypes.KnownSubType(typeof(ToDoBlock), BlockType.ToDo)]
    [JsonSubtypes.KnownSubType(typeof(ToggleBlock), BlockType.Toggle)]
    [JsonSubtypes.KnownSubType(typeof(UnsupportedBlock), BlockType.Unsupported)]
    public class BlockBase
    {
        public string Object => "block";
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BlockType Type { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }


        [JsonProperty("last_edited_time")]
        public string LastEditedTime { get; set; }


        [JsonProperty("has_children")]
        public virtual bool HasChildren { get; set; }
    }

    public class ParagraphBlock : BlockBase
    {
        public override BlockType Type => BlockType.Paragraph;

        public ParagraphClass Paragraph { get; set; }

        public class ParagraphClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }

    public class HeadingOneBlock : BlockBase
    {
        public override BlockType Type => BlockType.Heading_1;

        [JsonProperty("heading_1")]
        public HeadingOneClass Heading_1 { get; set; }

        public override bool HasChildren => false;

        public class HeadingOneClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
        }
    }

    public class HeadingTwoBlock : BlockBase
    {
        public override BlockType Type => BlockType.Heading_2;

        [JsonProperty("heading_2")]
        public HeadingTwoClass Heading_2 { get; set; }

        public override bool HasChildren => false;

        public class HeadingTwoClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
        }
    }

    public class HeadingThreeeBlock : BlockBase
    {
        public override BlockType Type => BlockType.Heading_3;

        [JsonProperty("heading_3")]
        public HeadingThreeClass Heading_3 { get; set; }

        public override bool HasChildren => false;

        public class HeadingThreeClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
        }
    }

    public class BulletedListItemBlock : BlockBase
    {
        public override BlockType Type => BlockType.BulletedListItem;

        [JsonProperty("bulleted_list_item")]
        public BulletedListItemClass BulletedListItem { get; set; }

        public class BulletedListItemClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }

    public class NumberedListItemBlock : BlockBase
    {

        public override BlockType Type => BlockType.NumberedListItem;

        [JsonProperty("numbered_list_item")]
        public NumberedListItemClass NumberedListItem { get; set; }

        public class NumberedListItemClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }

    public class ToDoBlock : BlockBase
    {
        public override BlockType Type => BlockType.ToDo;

        [JsonProperty("to_do")]
        public ToDoClass ToDo { get; set; }

        public class ToDoClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }

            public IEnumerable<BlockBase> Children { get; set; }
        }
    }

    public class ToggleBlock : BlockBase
    {
        public override BlockType Type => BlockType.Toggle;

        public ToggleClass Toggle { get; set; }

        public class ToggleClass
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }

    public class ChildPageBlock : BlockBase
    {
        public override BlockType Type => BlockType.ChildPage;

        [JsonProperty("child_page")]
        public ChildPageClass ChildPage { get; set; }

        public class ChildPageClass
        {
            public string Title { get; set; }
        }
    }

    public class UnsupportedBlock : BlockBase
    {
        public override BlockType Type => BlockType.Unsupported;
    }

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