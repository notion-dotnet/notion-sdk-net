using System.Collections.Generic;

namespace Notion.Client
{
    public class UrlProperty : Property
    {
        public override PropertyType Type => PropertyType.Url;
        public Dictionary<string, object> Url { get; set; }
    }
}
