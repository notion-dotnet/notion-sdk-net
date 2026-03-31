namespace Notion.Client
{
    public class SendFileUploadRequest : ISendFileUploadFormDataParameters, ISendFileUploadPathParameters
    {
        public FileData File { get; private set; }
        public string PartNumber { get; private set; }
        public string FileUploadId { get; private set; }

        private SendFileUploadRequest() { }

        public static SendFileUploadRequest Create(string fileUploadId, FileData file, string partNumber = null)
        {
            return new SendFileUploadRequest
            {
                FileUploadId = fileUploadId,
                File = file,
                PartNumber = partNumber
            };
        }
    }
}
