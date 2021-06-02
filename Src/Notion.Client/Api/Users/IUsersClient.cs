using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IUsersClient
    {
        Task<User> RetrieveAsync(string userId);
        Task<PaginatedList<User>> ListAsync();
    }
}
