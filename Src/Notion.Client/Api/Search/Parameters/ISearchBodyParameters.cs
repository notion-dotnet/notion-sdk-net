namespace Notion.Client
{
    public interface ISearchBodyParameters : IPaginationParameters
    {
        string Query { get; set; }
        SearchSort Sort { get; set; }
        SearchFilter Filter { get; set; }
    }
}
