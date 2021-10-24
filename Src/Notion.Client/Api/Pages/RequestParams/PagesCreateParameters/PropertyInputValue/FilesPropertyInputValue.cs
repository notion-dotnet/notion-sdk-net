using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// File property value object.
    /// </summary>
    public class FilesPropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// Array of File Object with name.
        /// </summary>
        [JsonProperty("files")]
        public List<FileObjectWithName> Files { get; set; }
    }
}
