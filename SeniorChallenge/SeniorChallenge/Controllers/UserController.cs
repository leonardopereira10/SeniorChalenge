using Microsoft.AspNetCore.Mvc;
using SeniorChallenge.InputModels;
using SeniorChallenge.Services;

namespace SeniorChallenge.Controllers
{
    /// <summary>
    /// The endpoint to manage users and authentication.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Realize the authentication for the user.
        /// </summary>
        /// <param name="user">User authentication information.</param>
        /// <returns>The bearer token to use this session.</returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Authenticate([FromBody] UserModel user)
        {
            return UserService.Authenticate(user);
        }
    }
}
