using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class AsyncTasksClientTests : IntegrationTestBase, IAsyncLifetime
{
    private readonly List<string> _createdPageIds = new();

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        foreach (var id in _createdPageIds)
        {
            await Client.Pages.UpdateAsync(id, new PagesUpdateParameters { InTrash = true });
        }
    }

    [Fact]
    public async Task RetrieveAsync_WithUnknownTaskId_ThrowsNotionApiException()
    {
        var act = () => Client.AsyncTasks.RetrieveAsync(Guid.NewGuid().ToString());

        await act.Should().ThrowAsync<NotionApiException>();
    }

    [Fact]
    public async Task CreateWithAsyncTaskAsync_ReturnsPageOrPollableTask()
    {
        var result = await Client.Pages.CreateWithAsyncTaskAsync(
            new PagesCreateParameters
            {
                Parent = new PageParentRequest { PageId = ParentPageId },
                Properties = new Dictionary<string, PropertyValue>(),
                Markdown = "# Async page\n\nCreated with allow_async."
            });

        if (!result.IsAsync)
        {
            // The API handled it synchronously.
            result.Result.Should().NotBeNull();
            _createdPageIds.Add(result.Result.Id);
            return;
        }

        var task = result.AsyncTask;
        task.Id.Should().NotBeNullOrEmpty();

        for (var attempt = 0; attempt < 30 && !task.IsFinished; attempt++)
        {
            await Task.Delay(TimeSpan.FromSeconds(task.PollAfterSeconds ?? 1));
            task = await Client.AsyncTasks.RetrieveAsync(task.Id);
        }

        task.Status.Should().Be(AsyncTaskStatus.Succeeded);
        task.Result.Should().NotBeNull();

        if (task.Result.TryGetValue("id", out var pageId) && pageId is string id)
        {
            _createdPageIds.Add(id);
        }
    }

    [Fact]
    public async Task PlainMethods_RejectAllowAsync()
    {
        var create = () => Client.Pages.CreateAsync(
            new PagesCreateParameters
            {
                Parent = new PageParentRequest { PageId = ParentPageId },
                Properties = new Dictionary<string, PropertyValue>(),
                AllowAsync = true
            });

        await create.Should().ThrowAsync<ArgumentException>();
    }
}
