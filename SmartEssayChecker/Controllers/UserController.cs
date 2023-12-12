using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Models.Users;
using SmartEssayChecker.Services.Foundations.Users;
using SmartEssayChecker.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker;


[ApiController]
[Route("api/[controller]")]

public class UsersController : RESTFulController
{
    private readonly IUserService userService;

    public UsersController(IUserService userService) =>
        this.userService = userService;

    [HttpPost]
    public async ValueTask<ActionResult<User>> Post(User user)
    {
        try
        {
            User persistedUser = await this.userService.AddUserAsync(user);
            return Created(persistedUser);
        }
        catch (UserValidationException userValidationException)
        {
            return BadRequest(userValidationException.InnerException);
        }
    }
}
