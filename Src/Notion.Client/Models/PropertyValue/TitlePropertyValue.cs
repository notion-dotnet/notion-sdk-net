using System.Collections.Generic;
using System.Text;

namespace Notion.Client
{
    public class TitlePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Title;
        public List<RichTextBase> Title { get; set; }

        public string GetAllPlainText()
        {
            if (Title.Count == 1) // to save some efficiency with most common case
                return Title[0].PlainText;
            
            var str = new StringBuilder();
            foreach (var richTextBase in Title)
                str.Append(richTextBase.PlainText);

            return str.ToString();
        }
    }
}
