using System.Collections.Generic;

namespace Notion.Client
{
    public class FilesProperty : Property
    {
        public override PropertyType Type => PropertyType.Files;
        public Dictionary<string, object> Files { get; set; }
    }
}
