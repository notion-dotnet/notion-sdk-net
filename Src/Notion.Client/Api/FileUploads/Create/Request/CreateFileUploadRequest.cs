namespace Notion.Client
{
    public class CreateFileUploadRequest : ICreateFileUploadBodyParameters
    {
        public FileUploadMode Mode { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public int? NumberOfParts { get; set; }

        public string ExternalUrl { get; set; }
    }
}
