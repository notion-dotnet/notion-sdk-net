namespace Notion.Client
{
    /// <summary>
    /// Tell full objects from partial ones. Some endpoints (for example search, data source queries and
    /// integrations without read access) can return a partial object that only has an <c>id</c>; its other
    /// members are <c>null</c> or default. Each method checks the same field as the equivalent
    /// <c>isFull*</c> helper in the Notion JavaScript SDK.
    /// </summary>
    public static class NotionTypeGuards
    {
        /// <summary>
        /// <c>true</c> if <paramref name="block"/> is a full block. A partial block has no <c>type</c> or
        /// timestamps and is deserialized as an <see cref="UnsupportedBlock"/> without a creation time.
        /// </summary>
        public static bool IsFullBlock(IBlock block)
        {
            return block != null && block.CreatedTime != default;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="page"/> is a full page (it has a <c>url</c>).
        /// </summary>
        public static bool IsFullPage(Page page)
        {
            return page != null && page.Url != null;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="dataSource"/> is a full data source (it has a <c>title</c>).
        /// </summary>
        public static bool IsFullDataSource(DataSource dataSource)
        {
            return dataSource != null && dataSource.Title != null;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="database"/> is a full database (it has a <c>title</c>).
        /// </summary>
        public static bool IsFullDatabase(Database database)
        {
            return database != null && database.Title != null;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="response"/> is a full <see cref="Page"/> or a full
        /// <see cref="DataSource"/>. Use it on the results of data source queries and search.
        /// </summary>
        public static bool IsFullPageOrDataSource(object response)
        {
            switch (response)
            {
                case DataSource dataSource:
                    return IsFullDataSource(dataSource);
                case Page page:
                    return IsFullPage(page);
                default:
                    return false;
            }
        }

        /// <summary>
        /// <c>true</c> if <paramref name="user"/> is a full user (it has a <c>type</c>).
        /// </summary>
        public static bool IsFullUser(User user)
        {
            return user != null && user.Type != null;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="comment"/> is a full comment (it has <c>created_by</c>).
        /// </summary>
        public static bool IsFullComment(Comment comment)
        {
            return comment != null && comment.CreatedBy != null;
        }

        /// <summary>
        /// <c>true</c> if <paramref name="view"/> is a full view (it has a <c>type</c>).
        /// </summary>
        public static bool IsFullView(View view)
        {
            return view != null && !string.IsNullOrEmpty(view.Type.ToString());
        }
    }
}
