using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale,
/// including sale number, date, customer details, branch details, and items.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// 
/// The data provided in this command is validated using the
/// <see cref="CreateSaleCommand"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the sale number for the new sale.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the date of the sale.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Gets or sets the unique identifier of the customer associated with the sale.
    /// </summary>
    public Guid CustomerId { get; set; }
    /// <summary>
    /// Gets or sets the name of the customer associated with the sale.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the unique identifier of the branch where the sale occurred.
    /// </summary>
    public Guid BranchId { get; set; }
    /// <summary>
    /// Gets or sets the name of the branch where the sale occurred.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public IEnumerable<CreateSaleItemCommand> Items { get; set; }

    /// <summary>
    /// Validates the current instance of <see cref="CreateSaleCommand"/> using the <see cref="CreateSaleValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new CreateSaleValidator();
        return validator.Validate(this);
    }

}
