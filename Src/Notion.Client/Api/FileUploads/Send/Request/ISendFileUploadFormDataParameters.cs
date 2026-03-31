namespace Notion.Client
{
    public interface ISendFileUploadFormDataParameters
    {
        /// <summary>
        /// The raw binary file contents to upload.
        /// </summary>
        FileData File { get; }

        /// <summary>
        /// When using a mode=multi_part File Upload to send files greater than 20 MB in parts, this is the current part number. 
        /// Must be an integer between 1 and 1000 provided as a string form field.
        /// </summary>
        string PartNumber { get; }
    }
}
