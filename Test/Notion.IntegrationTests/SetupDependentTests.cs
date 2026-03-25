using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class SetupDependentTests : IntegrationTestBase
{
    [Fact]
    public async Task Test()
    {
        var pageId = "3117ae0e1154800d9f12e2e8121d05ba";
        //var page = await Client.Pages.RetrieveAsync(pageId);
        //var blocks = await Client.Blocks.RetrieveAsync(pageId);
        var children = await Client.Blocks.RetrieveChildrenAsync(new BlockRetrieveChildrenRequest {BlockId = pageId});
        var childDatabase = children.Results.OfType<ChildDatabaseBlock>().FirstOrDefault();

        var database = await Client.Databases.RetrieveAsync(childDatabase.Id);
        //var properties = await Client.Databases.
    }

    [Fact]
    public async Task LoadView()
    {
        // Your database ID
        var databaseId = "3117ae0e-1154-805d-a64f-fc8361890d60";

        // First, retrieve the database to get data source references
        var db = await Client.Databases.RetrieveAsync(databaseId);

        // Check if this database has data sources
        var dataSourceRef = db.DataSources?.FirstOrDefault();
        string dataSourceId;

        if (dataSourceRef != null)
        {
            dataSourceId = dataSourceRef.DataSourceId;
        }
        else
        {
            // Database has no data sources - create one
            var newDataSource = await Client.DataSources.CreateAsync(new CreateDataSourceRequest
            {
                Parent = new DatabaseParentRequest { DatabaseId = databaseId },
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "Default View" } }
                },
                Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                {
                    { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } }
                }
            });
            dataSourceId = newDataSource.Id;
        }

        // Retrieve the data source to get available properties (schema)
        var dataSource = await Client.DataSources.RetrieveAsync(new RetrieveDataSourceRequest
        {
            DataSourceId = dataSourceId
        });

        // Properties available (schema)
        var availableProperties = dataSource.Properties;

        // Query entries
        var queryResponse = await Client.DataSources.QueryAsync(new QueryDataSourceRequest
        {
            DataSourceId = dataSourceId,
            PageSize = 100
        });

        // All entries
        var entries = queryResponse.Results;

        // NOTE: The Notion API does NOT expose view-specific configurations.
        // Views (table, board, calendar, etc.) with their specific filters, sorts,
        // and property visibility are UI-only concepts - not accessible via API.
    }
}
