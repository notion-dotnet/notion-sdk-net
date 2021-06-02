namespace Notion.Client
{
    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;
        public Date Date { get; set; }
    }

    public class Date
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
