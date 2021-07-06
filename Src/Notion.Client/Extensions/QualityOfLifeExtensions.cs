using System.Linq;
using System.Text;

namespace Notion.Client.Extensions
{
    public static class QualityOfLifeExtensions
    {
        public static (string Key, TitlePropertyValue Value) GetTitleProperty(this Page page)
        {
            var keyValuePair = page.Properties.First(x =>
                x.Value.Type == PropertyValueType.Title);
            return (
                Key: keyValuePair.Key, 
                Value: (TitlePropertyValue) keyValuePair.Value);
        }

        public static string GetAllPlainText(this TitlePropertyValue titlePropertyValue)
        {
            if (titlePropertyValue.Title.Count == 1) // to save some efficiency with most common case
                return titlePropertyValue.Title[0].PlainText;

            var str = new StringBuilder();
            foreach (var richTextBase in titlePropertyValue.Title)
                str.Append(richTextBase.PlainText);

            return str.ToString();
        }
    }
}