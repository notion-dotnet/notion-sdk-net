namespace Notion.Client
{
    public class NumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Number;
        public double Number { get; set; }
    }

}
