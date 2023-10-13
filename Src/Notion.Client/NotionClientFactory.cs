namespace Notion.Client
{
    public static class NotionClientFactory
    {
        public static NotionClient Create(ClientOptions options)
        {
            var restClient = new RestClient(options);

            return new NotionClient(
                restClient
                , new UsersClient(restClient)
                , new DatabasesClient(restClient)
                , new PagesClient(restClient)
                , new SearchClient(restClient)
                , new CommentsClient(restClient)
                , new BlocksClient(restClient)
                , new AuthenticationClient(restClient)
            );
        }
    }
}
