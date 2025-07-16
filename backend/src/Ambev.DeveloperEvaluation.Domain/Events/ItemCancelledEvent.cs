namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ItemCancelledEvent
{
    public Guid SaleItemId { get; }

    public ItemCancelledEvent(Guid saleItemId)
    {
        SaleItemId = saleItemId;
    }
}
