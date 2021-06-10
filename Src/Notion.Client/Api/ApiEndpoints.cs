namespace Notion.Client
{
    public static class ApiEndpoints
    {
        public static class DatabasesApiUrls
        {
            public static string Retrieve(string databaseId) => $"/v1/databases/{databaseId}";
            public static string List() => "/v1/databases";
            public static string Query(string databaseId) => $"/v1/databases/{databaseId}/query";
        }

        public static class UsersApiUrls
        {
            public static string Retrieve(string userId) => $"/v1/users/{userId}";
            public static string List() => "/v1/users";
        }

        public static class BlocksApiUrls
        {
            public static string RetrieveChildren(string blockId) => $"/v1/blocks/{blockId}/children";
            public static string AppendChildren(string blockId) => $"/v1/blocks/{blockId}/children";
        }

        public static class PagesApiUrls
        {
            public static string Create() => $"/v1/pages";
            public static string UpdateProperties(string pageId) => $"/v1/pages/{pageId}";
        }
    }
}
