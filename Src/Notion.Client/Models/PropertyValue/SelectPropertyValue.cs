namespace Notion.Client
{
    public class SelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Select;
        public SelectOption Select { get; set; }
    }

}
