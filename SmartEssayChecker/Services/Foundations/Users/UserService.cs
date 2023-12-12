using SmartEssayChecker.Brokers.Loggings;
using SmartEssayChecker.Brokers.Storages;
using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker.Services.Foundations.Users;

public partial class UserService : IUserService
{
    private IStorageBroker storageBroker;
    private ILoggingBroker loggingBroker;

    public UserService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<User> AddUserAsync(User user) =>
        TryCatch(async () =>
        {
            ValidateUserNotNull(user);
            return await this.storageBroker.InsertUserAsync(user);
        });

}