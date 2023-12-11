using SmartEssayChecker.Brokers.Storages;
using SmartEssayChecker.Models.Users;

namespace SmartEssayChecker.Services.Foundations.Users;

public class UserService : IUserService
{
    private IStorageBroker storageBroker;

    public UserService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public async ValueTask<User> InsertUserAsync(User user) =>
        await this.storageBroker.InsertUserAsync(user);
}