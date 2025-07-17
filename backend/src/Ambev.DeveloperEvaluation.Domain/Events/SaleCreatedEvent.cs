using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public class SaleCreatedEvent : Event
{
    public Guid SaleId { get; }
    public SaleCreatedEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
