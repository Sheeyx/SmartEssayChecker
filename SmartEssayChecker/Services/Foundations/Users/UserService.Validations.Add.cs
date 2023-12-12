using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker.Services.Foundations.Users;

public partial class UserService
{
    private void ValidateUserOnAdd(User user)
    {
        ValidateUserNotNull(user);
        Validate(
            (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
            (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
    }
    private static void ValidateUserNotNull(User user)
    {
        
        if (user is null)
        {
            throw new NullUserException();
        }
    }

    private dynamic IsInvalid(Guid id) => new
    {
        Condition = id == default,
        Message = "Id is required"
    };
    
    private dynamic IsInvalid(string text) => new
    {
        Condition = String.IsNullOrWhiteSpace(text),
        Message = "Text is required"
    };

    private static void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidUserException = new InvalidUserException();

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
            {
                invalidUserException.UpsertDataList(
                    key: parameter,
                    value: rule.Message);
            }
        }

        invalidUserException.ThrowIfContainsErrors();
    }
}