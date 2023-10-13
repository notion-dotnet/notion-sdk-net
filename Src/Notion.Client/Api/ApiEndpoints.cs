namespace Notion.Client
{
    public static class ApiEndpoints
    {
        public static class DatabasesApiUrls
        {
            public static string Create => "/v1/databases";

            public static string Retrieve(string databaseId)
            {
                return $"/v1/databases/{databaseId}";
            }

            public static string Query(string databaseId)
            {
                return $"/v1/databases/{databaseId}/query";
            }

            public static string Update(string databaseId)
            {
                return $"/v1/databases/{databaseId}";
            }
        }

        public static class UsersApiUrls
        {
            public static string Retrieve(string userId)
            {
                return $"/v1/users/{userId}";
            }

            public static string List()
            {
                return "/v1/users";
            }

            /// <summary>
            ///     Get the Uri <see cref="string" /> for retrieve your token's bot user.
            /// </summary>
            /// <returns>Returns a Uri <see cref="string" /> retrieve your token's bot user.</returns>
            public static string Me()
            {
                return "/v1/users/me";
            }
        }

        public static class BlocksApiUrls
        {
            public static string Retrieve(string blockId)
            {
                return $"/v1/blocks/{blockId}";
            }

            public static string Update(string blockId)
            {
                return $"/v1/blocks/{blockId}";
            }

            /// <summary>
            ///     Get the Uri <see cref="string" /> for deleting a block.
            /// </summary>
            /// <param name="blockId">Identifier for a Notion block</param>
            /// <returns>Returns a Uri <see cref="string" /> for deleting a block.</returns>
            public static string Delete(string blockId)
            {
                return $"/v1/blocks/{blockId}";
            }

            public static string RetrieveChildren(string blockId)
            {
                return $"/v1/blocks/{blockId}/children";
            }

            public static string AppendChildren(string blockId)
            {
                return $"/v1/blocks/{blockId}/children";
            }
        }

        public static class PagesApiUrls
        {
            public static string Create()
            {
                return "/v1/pages";
            }

            public static string Retrieve(string pageId)
            {
                return $"/v1/pages/{pageId}";
            }

            public static string Update(string pageId)
            {
                return $"/v1/pages/{pageId}";
            }

            public static string UpdateProperties(string pageId)
            {
                return $"/v1/pages/{pageId}";
            }

            /// <summary>
            ///     Get the Uri <see cref="string" /> for retrieve page property item
            /// </summary>
            /// <param name="pageId">Identifier for a Notion Page</param>
            /// <param name="propertyId">Identifier for a Notion Property</param>
            /// <returns>Returns a Uri <see cref="string" /> for Retrieve page property item</returns>
            public static string RetrievePropertyItem(string pageId, string propertyId)
            {
                return $"/v1/pages/{pageId}/properties/{propertyId}";
            }
        }

        public static class SearchApiUrls
        {
            public static string Search()
            {
                return "/v1/search";
            }
        }

        public static class CommentsApiUrls
        {
            public static string Retrieve()
            {
                return "/v1/comments";
            }

            public static string Create()
            {
                return "/v1/comments";
            }
        }

        public static class AuthenticationUrls
        {
            public static string CreateToken() => "/v1/oauth/token";
        }
    }
}
