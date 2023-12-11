using Force.DeepCloner;
using FluentAssertions;
using SmartEssayChecker.Models.Users;
using Xunit;
using Moq;

namespace SmartEssayChecker.Tests.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldAddUserAsync()
    {
        // given
        User randomUser = CreateRandomUser();
        User inputUser = randomUser;
        User persistedUser = inputUser;
        User expectedUser = persistedUser.DeepClone();

        this.storageBrokerMock.Setup(broker =>
                broker.InsertUserAsync(inputUser))
            .ReturnsAsync(expectedUser);

        // when
        User actualUser = await this.userService
            .AddUserAsync(inputUser);


        // then
        actualUser.Should().BeEquivalentTo(expectedUser);
        
        this.storageBrokerMock.Verify(broker => 
            broker.InsertUserAsync(inputUser), Times.Once);
        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}