using Xeptions;

namespace SmartEssayChecker.Services.Foundations.Users.Exceptions;

public class UserValidationException : Xeption
{
    public UserValidationException(Xeption innerException)
        :base (message: "User validation error occured," +
                        " fix the error and try again!", innerException)
    { }
}