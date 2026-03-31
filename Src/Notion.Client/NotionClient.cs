using System.Diagnostics.CodeAnalysis;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface INotionClient
    {
        IAuthenticationClient AuthenticationClient { get; }

        IUsersClient Users { get; }

        IDatabasesClient Databases { get; }

        IPagesClient Pages { get; }

        ISearchClient Search { get; }

        IBlocksClient Blocks { get; }

        ICommentsClient Comments { get; }

        IFileUploadsClient FileUploads { get; }

        IDataSourcesClient DataSources { get; }

        IRestClient RestClient { get; }
    }

    public class NotionClient : INotionClient
    {
        public NotionClient(
            IRestClient restClient,
            IUsersClient users,
            IDatabasesClient databases,
            IPagesClient pages,
            ISearchClient search,
            ICommentsClient comments,
            IBlocksClient blocks,
            IAuthenticationClient authenticationClient,
            IFileUploadsClient fileUploadsClient,
            IDataSourcesClient dataSourcesClient)
        {
            RestClient = restClient;
            Users = users;
            Databases = databases;
            Pages = pages;
            Search = search;
            Comments = comments;
            Blocks = blocks;
            AuthenticationClient = authenticationClient;
            FileUploads = fileUploadsClient;
            DataSources = dataSourcesClient;
        }

        public IAuthenticationClient AuthenticationClient { get; }

        public IUsersClient Users { get; }

        public IDatabasesClient Databases { get; }

        public IPagesClient Pages { get; }

        public ISearchClient Search { get; }

        public IBlocksClient Blocks { get; }

        public ICommentsClient Comments { get; }

        public IFileUploadsClient FileUploads { get; }

        public IDataSourcesClient DataSources { get; }

        public IRestClient RestClient { get; }
    }
}
