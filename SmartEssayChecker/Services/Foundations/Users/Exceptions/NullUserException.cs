using Xeptions;

namespace SmartEssayChecker.Services.Foundations.Users.Exceptions;

public class NullUserException : Xeption
{
    public NullUserException()
        : base(message: "User is null.")
    {}
}