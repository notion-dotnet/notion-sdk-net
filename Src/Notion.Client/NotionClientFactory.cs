namespace Notion.Client
{
    public static class NotionClientFactory
    {
        public static NotionClient Create(ClientOptions options)
        {
            var restClient = new RestClient(options);

            return new NotionClient(
                restClient: restClient
                , users: new UsersClient(restClient)
                , databases: new DatabasesClient(restClient)
                , pages: new PagesClient(restClient)
                , search: new SearchClient(restClient)
                , blocks: new BlocksClient(restClient)
                , comments: new CommentsClient(restClient)
            );
        }
    }
}
