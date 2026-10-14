using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class VerificationFilterTests : IntegrationTestBase, IAsyncLifetime
{
    private Page _page = null!;

    public async Task InitializeAsync()
    {
        _page = await Client.Pages.CreateAsync(
            PagesCreateParametersBuilder.Create(new PageParentRequest { PageId = ParentPageId }).Build());
    }

    public async Task DisposeAsync()
    {
        await Client.Pages.UpdateAsync(_page.Id, new PagesUpdateParameters { InTrash = true });
    }

        [Fact]
        public async Task QueryDataSourceAsync_WithVerificationFilters()
        {
            var database = await Client.Databases.CreateAsync(new DatabasesCreateRequest
            {
                Title = new List<RichTextBaseInput>
                {
                    new RichTextTextInput { Text = new Text { Content = "Verification filter DB" } }
                },
                InitialDataSource = new InitialDataSourceRequest
                {
                    Properties = new Dictionary<string, DataSourcePropertyConfigRequest>
                    {
                        { "Name", new TitleDataSourcePropertyConfigRequest { Title = new Dictionary<string, object>() } },
                        { "Verification", new VerificationDataSourcePropertyConfigRequest { Verification = new Dictionary<string, object>() } }
                    }
                },
                Parent = new PageParentOfDatabaseRequest { PageId = _page.Id }
            });
            var dataSourceId = database.DataSources.First().DataSourceId;

            var statusResponse = await Client.DataSources.QueryAsync(new QueryDataSourceRequest
            {
                DataSourceId = dataSourceId,
                Filter = new VerificationPropertyStatusFilter(
                    "Verification",
                    new VerificationPropertyStatusFilter.Condition(VerificationStatus.Verified))
            });

            var doesNotEqualResponse = await Client.DataSources.QueryAsync(new QueryDataSourceRequest
            {
                DataSourceId = dataSourceId,
                Filter = new VerificationPropertyDoesNotEqualFilter("Verification", VerificationStatus.Expired)
            });

            Assert.NotNull(statusResponse.Results);
            Assert.NotNull(doesNotEqualResponse.Results);
        }
}
