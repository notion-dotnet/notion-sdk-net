using System.Collections.Generic;

namespace Notion.Client
{
    public class FileProperty : Property
    {
        public override PropertyType Type => PropertyType.File;
        public Dictionary<string, object> File { get; set; }
    }
}
