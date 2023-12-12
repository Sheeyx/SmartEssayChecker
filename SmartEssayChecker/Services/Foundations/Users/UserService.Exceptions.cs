using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;
using Xeptions;

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
            throw CreateAndLogValidationException(nullUserException);
        }
        catch (InvalidUserException invalidUserException)
        {
            throw CreateAndLogValidationException(invalidUserException);
        }
    }

    private UserValidationException CreateAndLogValidationException(Xeption exception)
    {
        var userValidatoinException =
            new UserValidationException(exception);
        this.loggingBroker.LogError(userValidatoinException);
        return userValidatoinException;
    }
}