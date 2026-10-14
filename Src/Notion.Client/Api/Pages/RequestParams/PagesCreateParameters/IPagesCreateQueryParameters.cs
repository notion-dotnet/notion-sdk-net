namespace Notion.Client
{
    public interface IPagesCreateQueryParameters
    {
        /// <summary>
        /// Limits the returned page properties to the given property ids.
        /// </summary>
        System.Collections.Generic.IEnumerable<string> FilterProperties { get; set; }
    }
}
