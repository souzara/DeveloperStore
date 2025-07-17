using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent : Event
{
    public Guid SaleId { get; }
    public SaleModifiedEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
