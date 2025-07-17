using Ambev.DeveloperEvaluation.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Mongo;

/// <summary>
/// Represents an event log entity in MongoDB.
/// </summary>
[BsonIgnoreExtraElements]
public class EventLog
{
    /// <summary>
    /// Unique identifier for the event log.
    /// </summary>
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// Unique identifier for the event being logged.
    /// </summary>
    public string EventId { get; set; }

    /// <summary>
    /// Type of the event being logged.
    /// </summary>
    public string? EventType { get; set; }

    /// <summary>
    /// Data associated with the event being logged.
    /// </summary>
    public string? EventData { get; set; }

    /// <summary>
    /// Timestamp indicating when the event log was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the EventLog class with the specified parameters.
    /// </summary>
    public EventLog(string eventId, string? eventType, string? eventData, DateTime createdAt)
        : this(ObjectId.GenerateNewId().ToString(), eventId, eventType, eventData, createdAt)
    {

    }

    /// <summary>
    /// Initializes a new instance of the EventLog class with the specified parameters.
    /// </summary>
    public EventLog(string id, string eventId, string? eventType, string? eventData, DateTime createdAt)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty", nameof(id));
        if (string.IsNullOrWhiteSpace(eventType))
            throw new ArgumentException("EventType cannot be null or empty", nameof(eventType));
        if (string.IsNullOrWhiteSpace(eventData))
            throw new ArgumentException("EventData cannot be null or empty", nameof(eventData));

        Id = id;
        EventId = eventId;
        EventType = eventType;
        EventData = eventData;
        CreatedAt = createdAt;

    }

    /// <summary>
    /// Implicitly converts an Event to an EventLog.
    /// </summary>
    /// <param name="event">Event instance to convert.</param>
    public static implicit operator EventLog(Event @event)
    {
        var eventType = @event.GetType();

        return new EventLog(@event.EventId.ToString(), eventType.FullName ?? eventType.Name, JsonSerializer.Serialize(@event), @event.CreatedAt);
    }
}
