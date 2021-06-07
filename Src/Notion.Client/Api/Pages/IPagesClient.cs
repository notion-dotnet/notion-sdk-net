using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        Task<RetrievedPage> CreateAsync(CreatedPage page);
    }
}
