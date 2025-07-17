using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IEventBusService _eventBusService;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _createSaleHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Setups tests dependencias and creates fake data generators for CreateSaleHandler.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _eventBusService = Substitute.For<IEventBusService>();
        _mapper = Substitute.For<IMapper>();
        _createSaleHandler = new CreateSaleHandler(_saleRepository, _eventBusService, _mapper);
    }

    [Fact(DisplayName = "Given invalid create sale command should throws ValidationException")]
    public void GivenInvalidCreateSaleCommand_ShouldThrowsValidationException()
    {
        // Arrange
        var command = TestData.CreateSaleHandlerTestData.GenerateValid();
        command.SaleNumber = string.Empty;

        // Act & Assert
        Assert.Throws<FluentValidation.ValidationException>(() => _createSaleHandler.Handle(command, default).GetAwaiter().GetResult());
    }

    [Fact(DisplayName = "Given valid create sale command should create sale and publish event")]
    public async Task GivenValidCreateSaleCommand_ShouldCreateSaleAndPublishEvent()
    {
        // Arrange
        var command = TestData.CreateSaleHandlerTestData.GenerateValid();
        var sale = Domain.Entities.TestData.SaleTestData.GenerateValidSale(command);
        var createSaleResult = TestData.CreateSaleHandlerTestData.GenerateCreateSaleResult(sale);
        var saleCreatedEvent = new SaleCreatedEvent(sale.Id);
        var ct = new CancellationToken();

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(sale, default).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(createSaleResult);
        _mapper.Map<SaleCreatedEvent>(sale).Returns(saleCreatedEvent);

        _eventBusService.PublishAsync(Arg.Is(saleCreatedEvent)).Returns(Task.CompletedTask);

        // Act

        var result = await _createSaleHandler.Handle(command, ct);

        // Assert
        Assert.NotNull(result);
        Assert.True(sale.TotalAmount > 0, "TotalAmount should be greater than zero");
        await _eventBusService.Received(1).PublishAsync(Arg.Is(saleCreatedEvent));
        Assert.Equal(sale.Id, result.Id);

    }

}
