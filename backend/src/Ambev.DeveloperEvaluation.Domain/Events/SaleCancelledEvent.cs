using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public class SaleCancelledEvent : Event
{
    public Guid SaleId { get; }
    public SaleCancelledEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
