using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Mongo;
public class EventLogTests
{

    [Fact(DisplayName = "Creating EventLog with empty id should throw ArgumentException")]
    public void Given_EmptyId_When_CreatingEventLog_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var eventId = "event123";
        var eventType = "EventType";
        var eventData = "{\"key\":\"value\"}";
        var createdAt = DateTime.UtcNow;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new EventLog(string.Empty, eventId, eventType, eventData, createdAt));
    }

    [Fact(DisplayName = "Creating EventLog with empty eventType should throw ArgumentException")]
    public void Given_EmptyEventType_When_CreatingEventLog_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var id = "60c72b2f9b1e8d3f4c8b4567";
        var eventId = "event123";
        var eventType = string.Empty;
        var eventData = "{\"key\":\"value\"}";
        var createdAt = DateTime.UtcNow;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new EventLog(id, eventId, eventType, eventData, createdAt));
    }

    [Fact(DisplayName = "Creating EventLog with empty eventData should throw ArgumentException")]
    public void Given_EmptyEventData_When_CreatingEventLog_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var id = "60c72b2f9b1e8d3f4c8b4567";
        var eventId = "event123";
        var eventType = "EventType";
        var eventData = string.Empty;
        var createdAt = DateTime.UtcNow;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new EventLog(id, eventId, eventType, eventData, createdAt));
    }
    [Fact(DisplayName = "Creating EventLog with valid parameters should succeed")]
    public void Given_ValidParameters_When_CreatingEventLog_Then_ShouldSucceed()
    {
        // Arrange
        var id = "60c72b2f9b1e8d3f4c8b4567";
        var eventId = "event123";
        var eventType = "EventType";
        var eventData = "{\"key\":\"value\"}";
        var createdAt = DateTime.UtcNow;
        // Act
        var eventLog = new EventLog(id, eventId, eventType, eventData, createdAt);
        // Assert
        Assert.NotNull(eventLog);
        Assert.Equal(id, eventLog.Id);
        Assert.Equal(eventId, eventLog.EventId);
        Assert.Equal(eventType, eventLog.EventType);
        Assert.Equal(eventData, eventLog.EventData);
        Assert.Equal(createdAt, eventLog.CreatedAt);
    }

    [Fact(DisplayName = "Creating EventLog with generated Id should succeed")]
    public void Given_GeneratedId_When_CreatingEventLog_Then_ShouldSucceed()
    {
        // Arrange
        var eventId = "event123";
        var eventType = "EventType";
        var eventData = "{\"key\":\"value\"}";
        var createdAt = DateTime.UtcNow;
        // Act
        var eventLog = new EventLog(eventId, eventType, eventData, createdAt);
        // Assert
        Assert.NotNull(eventLog);
        Assert.False(string.IsNullOrWhiteSpace(eventLog.Id));
        Assert.Equal(eventId, eventLog.EventId);
        Assert.Equal(eventType, eventLog.EventType);
        Assert.Equal(eventData, eventLog.EventData);
        Assert.Equal(createdAt, eventLog.CreatedAt);
    }
}
