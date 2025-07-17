using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories.Mongo;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.EventBus
{
    public class EventBusService : IEventBusService
    {
        private readonly IEventLogRepository _eventLogRepository;
        private readonly ILogger<EventBusService> _logger;

        public EventBusService(IEventLogRepository eventLogRepository, ILogger<EventBusService> logger)
        {
            _eventLogRepository = eventLogRepository;
            _logger = logger;
        }
        public async Task PublishAsync<T>(T @event) where T : Event
        {
            await _eventLogRepository.CreateAsync(@event);

            _logger.LogInformation($"Publishing event {@event} with data: {JsonSerializer.Serialize(@event)}");

        }
    }
}
