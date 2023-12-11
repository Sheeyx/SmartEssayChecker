using SmartEssayChecker.Models.Users;

namespace SmartEssayChecker.Services.Foundations.Users;

public interface IUserService
{
    ValueTask<User> InsertUserAsync(User user);
}