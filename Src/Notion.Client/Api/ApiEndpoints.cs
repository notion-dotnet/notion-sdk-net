using System;

namespace Notion.Client
{
    public static class ApiEndpoints
    {
        public static class DatabasesApiUrls
        {
            public static string Retrieve(string databaseId) => $"/v1/databases/{databaseId}";
            public static string List() => "/v1/databases";
            public static string Query(string databaseId) => $"/v1/databases/{databaseId}/query";
            public static string Create => "/v1/databases";
            public static string Update(string databaseId) => $"/v1/databases/{databaseId}";
        }

        public static class UsersApiUrls
        {
            public static string Retrieve(string userId) => $"/v1/users/{userId}";
            public static string List() => "/v1/users";

            /// <summary>
            /// Get the <see cref="uri string"/> for retrieve your token's bot user.
            /// </summary>
            /// <returns>Returns a <see cref="uri string"/> retrieve your token's bot user.</returns>
            public static string Me() => "/v1/users/me";
        }

        public static class BlocksApiUrls
        {
            public static string Retrieve(string blockId) => $"/v1/blocks/{blockId}";
            public static string Update(string blockId) => $"/v1/blocks/{blockId}";

            /// <summary>
            /// Get the <see cref="uri string"/> for deleting a block.
            /// </summary>
            /// <param name="blockId">Identifier for a Notion block</param>
            /// <returns>Returns a <see cref="uri string"/> for deleting a block.</returns>
            public static string Delete(string blockId) => $"/v1/blocks/{blockId}";

            public static string RetrieveChildren(string blockId) => $"/v1/blocks/{blockId}/children";
            public static string AppendChildren(string blockId) => $"/v1/blocks/{blockId}/children";
        }

        public static class PagesApiUrls
        {
            public static string Create() => $"/v1/pages";
            public static string Retrieve(string pageId) => $"/v1/pages/{pageId}";
            public static string Update(string pageId) => $"/v1/pages/{pageId}";
            public static string UpdateProperties(string pageId) => $"/v1/pages/{pageId}";
        }

        public static class SearchApiUrls
        {
            public static string Search() => "/v1/search";
        }
    }
}
