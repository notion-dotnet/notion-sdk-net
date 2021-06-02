using System.Collections.Generic;

namespace Notion.Client
{
    public class CheckboxProperty : Property
    {
        public override PropertyType Type => PropertyType.Checkbox;
        public Dictionary<string, object> Checkbox { get; set; }
    }
}
