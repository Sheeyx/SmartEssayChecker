using System.Linq.Expressions;
using Moq;
using SmartEssayChecker.Brokers.Loggings;
using SmartEssayChecker.Brokers.Storages;
using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users;
using Tynamix.ObjectFiller;

namespace SmartEssayChecker.Tests.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IUserService userService;

    public UserServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.userService = new UserService(
            storageBroker: this.storageBrokerMock.Object);
    }

    private static User CreateRandomUser() =>
        CreateUserFiller().Create();

    private static Filler<User> CreateUserFiller() =>
        new Filler<User>();
}