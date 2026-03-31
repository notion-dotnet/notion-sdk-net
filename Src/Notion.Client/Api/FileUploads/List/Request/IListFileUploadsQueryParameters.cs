namespace Notion.Client
{
    public interface IListFileUploadsQueryParameters
    {
        /// <summary>
        /// Filter file uploads by specifying the status. Supported values are "pending", "uploaded", "expired", "failed".
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// If supplied, this endpoint will return a page of results starting after the cursor provided. 
        /// If not supplied, this endpoint will return the first page of results.
        /// </summary>
        string StartCursor { get; set; }

        /// <summary>
        /// The number of items from the full list desired in the response. Maximum: 100
        /// Default to 100
        /// </summary>
        int? PageSize { get; set; }
    }
}
