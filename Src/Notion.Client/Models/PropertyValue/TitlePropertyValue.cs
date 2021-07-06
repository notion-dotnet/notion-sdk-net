using System.Collections.Generic;

namespace Notion.Client
{
    public class TitlePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Title;
        public List<RichTextBase> Title { get; set; }
    }
}
