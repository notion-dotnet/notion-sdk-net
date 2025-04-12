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
}
