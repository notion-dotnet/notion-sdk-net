namespace Notion.Client
{
    public class EmailPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Email;

        public string Email { get; set; }
    }
}
