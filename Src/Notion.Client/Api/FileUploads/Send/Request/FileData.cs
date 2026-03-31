using System.IO;

namespace Notion.Client
{
    public class FileData
    {
        /// <summary>
        /// The name of the file being uploaded.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The content of the file being uploaded.
        /// </summary>
        public Stream Data { get; set; }

        /// <summary>
        /// The MIME type of the file being uploaded.
        /// </summary>
        public string ContentType { get; set; }
    }
}
