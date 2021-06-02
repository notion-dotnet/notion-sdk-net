using System.Collections.Generic;

namespace Notion.Client
{
    public class EmailProperty : Property
    {
        public override PropertyType Type => PropertyType.Email;
        public Dictionary<string, object> Email { get; set; }
    }
}
