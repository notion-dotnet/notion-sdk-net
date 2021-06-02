namespace Notion.Client
{
    public class UrlPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Url;

        public string Url { get; set; }
    }

}
