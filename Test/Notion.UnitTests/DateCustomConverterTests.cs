using System;
using System.IO;
using Newtonsoft.Json;
using Notion.Client;
using Xunit;

namespace NotionUnitTests.PropertyValue;

public class DateCustomConverterTests
{
    private readonly DateCustomConverter _converter = new();
    private readonly JsonSerializer _serializer = new();

    [Fact]
    public void Serialize_null_writes_null()
    {
        // Arrange
        Date date = null;
        var stringWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(stringWriter);

        // Act
        _converter.WriteJson(jsonWriter, date, _serializer);
        jsonWriter.Flush();

        // Assert
        Assert.Equal("null", stringWriter.ToString());
    }

    [Fact]
    public void Serialize_start_date_only_produces_correct_json()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 0, 0, 0, TimeSpan.Zero),
            IncludeTime = false
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.Contains("\"start\":\"2023-05-15\"", json);
        Assert.DoesNotContain("\"end\":", json);
        Assert.DoesNotContain("\"time_zone\":", json);
    }

    [Fact]
    public void Serialize_start_and_end_dates_produces_correct_json()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 0, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2023, 5, 20, 0, 0, 0, TimeSpan.Zero),
            IncludeTime = false
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.Contains("\"start\":\"2023-05-15\"", json);
        Assert.Contains("\"end\":\"2023-05-20\"", json);
        Assert.DoesNotContain("\"time_zone\":", json);
    }

    [Fact]
    public void Serialize_with_time_included_formats_time_correctly()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero),
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.Contains("\"start\":\"2023-05-15T14:30:45Z\"", json);
    }

    [Fact]
    public void Serialize_with_time_zone_includes_time_zone()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero),
            TimeZone = "Europe/London",
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.Contains("\"start\":\"2023-05-15T14:30:45Z\"", json);
        Assert.Contains("\"time_zone\":\"Europe/London\"", json);
    }

    [Fact]
    public void Deserialize_null_returns_null()
    {
        // Arrange
        const string Json = "null";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_start_date_only_returns_correct_date()
    {
        // Arrange
        const string Json = "{\"start\":\"2023-05-15\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 0, 0, 0, TimeSpan.Zero), result.Start);
        Assert.Null(result.End);
        Assert.Null(result.TimeZone);
        Assert.False(result.IncludeTime);
    }

    [Fact]
    public void Deserialize_with_time_sets_include_time_flag()
    {
        // Arrange
        const string Json = "{\"start\":\"2023-05-15T14:30:45\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero), result.Start);
        Assert.True(result.IncludeTime);
    }

    [Fact]
    public void Deserialize_with_start_end_and_time_zone_returns_complete_date()
    {
        // Arrange
        const string Json = "{\"start\":\"2023-05-15T14:30:45\",\"end\":\"2023-05-20T16:45:00\",\"time_zone\":\"America/New_York\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero), result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.Zero), result.End);
        Assert.Equal("America/New_York", result.TimeZone);
        Assert.True(result.IncludeTime);
    }

    [Fact]
    public void Date_property_value_serialize_deserialize_maintains_data()
    {
        // Arrange
        var datePropertyValue = new DatePropertyValue
        {
            Date = new Date
            {
                Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.Zero),
                TimeZone = "Europe/Berlin",
                IncludeTime = true
            }
        };

        // Act
        var json = JsonConvert.SerializeObject(datePropertyValue);
        var result = JsonConvert.DeserializeObject<DatePropertyValue>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(PropertyValueType.Date, result.Type);
        Assert.NotNull(result.Date);
        Assert.Equal(datePropertyValue.Date.Start, result.Date.Start);
        Assert.Equal(datePropertyValue.Date.End, result.Date.End);
        Assert.Equal(datePropertyValue.Date.TimeZone, result.Date.TimeZone);
        Assert.Equal(datePropertyValue.Date.IncludeTime, result.Date.IncludeTime);
    }

    [Fact]
    public void Round_trip_preserves_data()
    {
        // Arrange
        var originalDate = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero),
            End = new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.Zero),
            TimeZone = "Europe/Berlin",
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(originalDate);
        var deserializedDate = JsonConvert.DeserializeObject<Date>(json);

        // Assert
        Assert.NotNull(deserializedDate);
        Assert.Equal(originalDate.Start, deserializedDate.Start);
        Assert.Equal(originalDate.End, deserializedDate.End);
        Assert.Equal(originalDate.TimeZone, deserializedDate.TimeZone);
        Assert.True(deserializedDate.IncludeTime);
    }

    [Fact]
    public void Serialize_with_timezone_offset_converts_to_utc()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.FromHours(2)), // +02:00 offset
            End = new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.FromHours(-5)), // -05:00 offset
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert - dates should be converted to UTC
        Assert.Contains("\"start\":\"2023-05-15T12:30:45Z\"", json); // 14:30:45 +02:00 -> 12:30:45 UTC
        Assert.Contains("\"end\":\"2023-05-20T21:45:00Z\"", json); // 16:45:00 -05:00 -> 21:45:00 UTC
    }

    [Fact]
    public void Deserialize_with_timezone_offset_preserves_utc()
    {
        // Arrange - API returns UTC dates
        const string Json = "{\"start\":\"2023-05-15T12:30:45Z\",\"end\":\"2023-05-20T21:45:00Z\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 12, 30, 45, TimeSpan.Zero), result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 21, 45, 0, TimeSpan.Zero), result.End);
        Assert.True(result.IncludeTime);
    }

    [Fact]
    public void Round_trip_with_timezone_offsets_preserves_utc_equivalent()
    {
        // Arrange - date with timezone offset
        var originalDate = new Date
        {
            Start = new DateTimeOffset(2024, 6, 26, 0, 0, 0, TimeSpan.FromHours(1)), // +01:00 offset
            End = new DateTimeOffset(2025, 12, 8, 0, 0, 0, TimeSpan.Zero), // UTC
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(originalDate);
        var deserializedDate = JsonConvert.DeserializeObject<Date>(json);

        // Assert - should preserve the UTC equivalent times
        Assert.NotNull(deserializedDate);
        // Start: 2024-06-26T00:00:00+01:00 -> 2024-06-25T23:00:00Z
        Assert.Equal(new DateTimeOffset(2024, 6, 25, 23, 0, 0, TimeSpan.Zero), deserializedDate.Start);
        Assert.Equal(new DateTimeOffset(2025, 12, 8, 0, 0, 0, TimeSpan.Zero), deserializedDate.End);
        Assert.True(deserializedDate.IncludeTime);
    }

    [Fact]
    public void Serialize_date_only_without_time_uses_date_format()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.FromHours(2)),
            End = new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.FromHours(-3)),
            IncludeTime = false
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert - should use date format (yyyy-MM-dd) regardless of timezone
        Assert.Contains("\"start\":\"2023-05-15\"", json);
        Assert.Contains("\"end\":\"2023-05-20\"", json);
    }

    [Fact]
    public void Deserialize_empty_start_string_returns_null_start()
    {
        // Arrange
        const string Json = "{\"start\":\"\",\"end\":\"2023-05-20\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 0, 0, 0, TimeSpan.Zero), result.End);
        Assert.False(result.IncludeTime); // Should be false since Start is null
    }

    [Fact]
    public void Deserialize_with_space_separator_sets_include_time_flag()
    {
        // Arrange - some systems might use space instead of T
        const string Json = "{\"start\":\"2023-05-15 14:30:45\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero), result.Start);
        Assert.True(result.IncludeTime);
    }

    [Fact]
    public void Serialize_only_start_date_omits_end_property()
    {
        // Arrange
        var date = new Date
        {
            Start = new DateTimeOffset(2023, 5, 15, 14, 30, 45, TimeSpan.Zero),
            End = null,
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.Contains("\"start\":\"2023-05-15T14:30:45Z\"", json);
        Assert.DoesNotContain("\"end\":", json);
    }

    [Fact]
    public void Serialize_only_end_date_omits_start_property()
    {
        // Arrange
        var date = new Date
        {
            Start = null,
            End = new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.Zero),
            IncludeTime = true
        };

        // Act
        var json = JsonConvert.SerializeObject(date);

        // Assert
        Assert.DoesNotContain("\"start\":", json);
        Assert.Contains("\"end\":\"2023-05-20T16:45:00Z\"", json);
    }

    [Fact]
    public void Deserialize_with_only_end_time_sets_include_time_flag()
    {
        // Arrange - Only end date has time, start is date-only
        const string Json = "{\"start\":\"2023-05-15\",\"end\":\"2023-05-20T16:45:00\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 0, 0, 0, TimeSpan.Zero), result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 16, 45, 0, TimeSpan.Zero), result.End);
        Assert.True(result.IncludeTime); // Should be true because End has time
    }

    [Fact]
    public void Deserialize_with_only_start_time_sets_include_time_flag()
    {
        // Arrange - Only start date has time, end is date-only
        const string Json = "{\"start\":\"2023-05-15T14:30:00\",\"end\":\"2023-05-20\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 14, 30, 0, TimeSpan.Zero), result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 0, 0, 0, TimeSpan.Zero), result.End);
        Assert.True(result.IncludeTime); // Should be true because Start has time
    }

    [Fact]
    public void Deserialize_with_neither_start_nor_end_time_clears_include_time_flag()
    {
        // Arrange - Both dates are date-only
        const string Json = "{\"start\":\"2023-05-15\",\"end\":\"2023-05-20\"}";

        // Act
        var result = JsonConvert.DeserializeObject<Date>(Json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTimeOffset(2023, 5, 15, 0, 0, 0, TimeSpan.Zero), result.Start);
        Assert.Equal(new DateTimeOffset(2023, 5, 20, 0, 0, 0, TimeSpan.Zero), result.End);
        Assert.False(result.IncludeTime); // Should be false because neither has time
    }
}
