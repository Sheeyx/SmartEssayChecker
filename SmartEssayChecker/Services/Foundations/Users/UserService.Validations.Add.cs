using SmartEssayChecker.Models.Users;

namespace SmartEssayChecker.Services.Foundations.Users;

public partial class UserService
{
    private static void ValidateUserNotNull(User user)
    {
        
        if (user is null)
        {
            throw new NullReferenceException();
        }
    }
}