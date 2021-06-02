using System.Collections.Generic;

namespace Notion.Client
{
    public class PeoplePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.People;
        public List<User> People { get; set; }
    }

}
