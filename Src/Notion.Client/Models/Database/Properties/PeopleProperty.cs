using System.Collections.Generic;

namespace Notion.Client
{
    public class PeopleProperty : Property
    {
        public override PropertyType Type => PropertyType.People;
        public Dictionary<string, object> People { get; set; }
    }
}
