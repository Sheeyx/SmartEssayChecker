using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker.Services.Foundations.Users;

public partial class UserService
{
    private delegate ValueTask<User> ReturningUserFunction();

    private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
    {
        try
        {
            return await returningUserFunction();
        }
        catch (NullUserException nullUserException)
        {
            var userValidatoinException =
                new UserValidationException(nullUserException);
            this.loggingBroker.LogError(userValidatoinException);
            throw userValidatoinException;
        }   
    }
}