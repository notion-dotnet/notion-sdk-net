using System.Linq;

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
    }
}