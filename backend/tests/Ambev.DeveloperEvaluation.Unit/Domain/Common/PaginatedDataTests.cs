using Ambev.DeveloperEvaluation.Domain.Common;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Common
{
    public class PaginatedDataTests
    {

        [Fact(DisplayName = "Should create a paginated result with the correct properties")]
        public void Given_ValidParameters_WhenCreatingPaginatedData_ThenShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var items = new List<string>();
            for (int i = 0; i < 10; i++)
                items.Add($"Item {i + 1}");

            var page = 1;
            var pageSize = 10;
            var totalItems = 200;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            // Act
            var paginatedResult = new PaginatedData<string>(items, page, pageSize, totalItems);

            // Assert
            Assert.Equal(items, paginatedResult.Items);
            Assert.Equal(pageSize, paginatedResult.PageSize);
            Assert.Equal(page, paginatedResult.Page);
            Assert.Equal(totalItems, paginatedResult.TotalItems);
            Assert.Equal(totalPages, paginatedResult.TotalPages);
        }

    }
}
