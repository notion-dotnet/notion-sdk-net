using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ISearchClient
    {
        /// <summary>
        /// Searches all original pages, databases, and child pages/databases that are shared with the integration. 
        /// 
        /// It will not return linked databases, since these duplicate their source databases.
        /// </summary>
        /// <param name="parameters">Search filters and body parameters</param>
        /// <returns><see cref="PaginatedList{IObject}"/></returns>
        Task<PaginatedList<IObject>> SearchAsync(SearchParameters parameters);
    }
}
