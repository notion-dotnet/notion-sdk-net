using System;

namespace Notion.Client
{
    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;
        public Date Date { get; set; }
    }

    public class Date
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
