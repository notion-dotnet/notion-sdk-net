using System.Collections.Generic;

namespace Notion.Client
{
    public class CheckboxUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
