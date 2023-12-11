using SmartEssayChecker.Brokers.Loggings;
using SmartEssayChecker.Brokers.Storages;
using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker.Services.Foundations.Users;

public class UserService : IUserService
{
    private IStorageBroker storageBroker;
    private ILoggingBroker loggingBroker;

    public UserService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<User> AddUserAsync(User user)
    {
        try
        {
            if (user is null)
            {
                throw new NullUserException();
            }
            return await this.storageBroker.InsertUserAsync(user);
        }
        catch (NullUserException nullUserException)
        {
            var userValidationException =
                new UserValidationException(nullUserException);

            this.loggingBroker.LogError(userValidationException);

            throw userValidationException;
        }
    }
        
}