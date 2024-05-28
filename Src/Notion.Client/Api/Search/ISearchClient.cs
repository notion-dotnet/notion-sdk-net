using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface ISearchClient
    {
        /// <summary>
        ///     Searches all original pages, databases, and child pages/databases that are shared with the integration.
        ///     It will not return linked databases, since these duplicate their source databases.
        /// </summary>
        /// <param name="request">Search filters and body parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     <see cref="PaginatedList{IObject}" />
        /// </returns>
        Task<SearchResponse> SearchAsync(
            SearchRequest request,
            CancellationToken cancellationToken = default
        );
    }
}
