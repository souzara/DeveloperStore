using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface IEventBusService
{
    Task PublishAsync<T>(T @event) where T : Event;

}
