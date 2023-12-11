using System.Linq.Expressions;
using Moq;
using SmartEssayChecker.Brokers.Loggings;
using SmartEssayChecker.Brokers.Storages;
using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SmartEssayChecker.Tests.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IUserService userService;

    public UserServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();

        this.userService =
            new UserService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
    }

    private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
        actualException => actualException.SameExceptionAs(expectedException);

    private static User CreateRandomUser() =>
        CreateUserFiller().Create();

    private static Filler<User> CreateUserFiller() =>
        new Filler<User>();
}