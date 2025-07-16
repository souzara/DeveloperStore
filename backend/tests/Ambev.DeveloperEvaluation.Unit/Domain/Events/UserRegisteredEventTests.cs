using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Events;
public class UserRegisteredEventTests
{

    [Fact(DisplayName = "UserRegisteredEvent should initialize with User")]
    public void UserRegisteredEvent_ShouldInitializeWithUser()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        var userRegisteredEvent = new UserRegisteredEvent(user);

        // Assert
        Assert.Equal(user, userRegisteredEvent.User);
    }
}
