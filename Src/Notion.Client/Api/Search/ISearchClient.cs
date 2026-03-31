using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ISearchClient
    {
        /// <summary>
        /// Searches all parent or child pages and data_sources that have been shared with an integration.
        ///  
        /// Returns all pages or data_sources , excluding duplicated linked databases, that have titles that include the query param. 
        /// If no query param is provided, then the response contains all pages or data_sources that have been shared with the integration. 
        /// The results adhere to any limitations related to an integration’s capabilities.
        /// </summary>
        /// <param name="request">Search filters and body parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     <see cref="SearchResponse" />
        /// </returns>
        Task<SearchResponse> SearchAsync(
            SearchRequest request,
            CancellationToken cancellationToken = default
        );
    }
}
