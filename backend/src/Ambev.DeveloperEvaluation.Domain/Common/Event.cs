namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class Event
    {
        public Guid EventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EventName { get; }
        public Event()
        {
            EventId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            EventName = GetType().Name;
        }
    }
}
