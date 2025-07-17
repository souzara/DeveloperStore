using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleItemCancelledEvent : Event
{
    public Guid SaleId { get; }
    public Guid SaleItemId { get; }

    public SaleItemCancelledEvent(Guid saleId, Guid saleItemId)
    {
        SaleId = saleId;
        SaleItemId = saleItemId;
    }
}
