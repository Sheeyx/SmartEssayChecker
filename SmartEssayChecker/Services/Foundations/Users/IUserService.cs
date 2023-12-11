using SmartEssayChecker.Models.Users;

namespace SmartEssayChecker.Services.Foundations.Users;

public interface IUserService
{
    ValueTask<User> AddUserAsync(User user);
}