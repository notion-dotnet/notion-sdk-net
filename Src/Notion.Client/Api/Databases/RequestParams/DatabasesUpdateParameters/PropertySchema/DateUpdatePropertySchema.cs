using System.Collections.Generic;

namespace Notion.Client
{
    public class DateUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> Date { get; set; }
    }
}
