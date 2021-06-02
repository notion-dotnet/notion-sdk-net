using System.Collections.Generic;

namespace Notion.Client
{
    public class TitleProperty : Property
    {
        public override PropertyType Type => PropertyType.Title;
        public Dictionary<string, object> Title { get; set; }
    }
}
