using System.Collections.Generic;

namespace Notion.Client
{
    public class DateProperty : Property
    {
        public override PropertyType Type => PropertyType.Date;
        public Dictionary<string, object> Date { get; set; }
    }
}
