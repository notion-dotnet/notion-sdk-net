namespace Notion.Client
{
    public class CheckboxPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Checkbox;

        public bool Checkbox { get; set; }
    }
}
