using System.Collections.Generic;

namespace Notion.Client
{
    public class FilesPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Files;

        public List<FileValue> Files { get; set; }
    }

    public class FileValue
    {
        public string Name { get; set; }
    }
}
