using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Notion.Client;
using Xunit;

namespace Notion.IntegrationTests;

public class MeetingNotesQueryTests : IntegrationTestBase
{
    [Fact]
    public async Task QueryMeetingNotesAsync_WithTypedFilterAndSort()
    {
        var response = await Client.Blocks.QueryMeetingNotesAsync(
            new QueryMeetingNotesRequest
            {
                Filter = MeetingNotesCombinatorFilter.And(
                    new MeetingNotesPropertyFilter(
                        MeetingNotesPropertyName.Title,
                        MeetingNotesFilterCondition.Empty(false)),
                    new MeetingNotesPropertyFilter(
                        MeetingNotesPropertyName.CreatedTime,
                        MeetingNotesFilterCondition.DateRelative(
                            MeetingNotesFilterOperator.DateIsBefore, "today"))),
                Sort = new List<MeetingNotesSort>
                {
                    new MeetingNotesSort
                    {
                        Property = MeetingNotesPropertyName.CreatedTime,
                        Direction = MeetingNotesSort.Descending
                    }
                },
                PageSize = 10
            }
        );

        response.Should().NotBeNull();
        response.Results.Should().NotBeNull();
    }
}
