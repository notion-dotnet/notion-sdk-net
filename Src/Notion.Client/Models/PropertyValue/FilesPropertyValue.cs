using System.Collections.Generic;

namespace Notion.Client
{
    public class FilesPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Files;

        public List<FileObjectWithName> Files { get; set; }
    }
}
