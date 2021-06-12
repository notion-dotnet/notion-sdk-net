using System.Threading.Tasks;

namespace Notion.Client
{
    public interface ISearchClient
    {
        Task<PaginatedList<IObject>> SearchAsync(SearchParameters parameters);
    }
}
