namespace Notion.Client.List.Request
{
    public interface IListUsersQueryParameters : IPaginationParameters
    {
    }

    public class ListUsersParameters : IListUsersQueryParameters
    {
        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
