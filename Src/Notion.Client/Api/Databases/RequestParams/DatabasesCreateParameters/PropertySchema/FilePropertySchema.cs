using System.Collections.Generic;

namespace Notion.Client
{
    public class FilePropertySchema : IPropertySchema
    {
        public Dictionary<string, object> Files { get; set; }
    }
}
