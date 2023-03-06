using IS_Projekt.Core;
using IS_Projekt.Server.Entities;
using IS_Projekt.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IS_Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var response = userService.Authenticate(request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("us")]
        public ActionResult<User> AllUsers()
        {
            var response = userService.GetUsers();

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("usAuth")]
        public ActionResult<IEnumerable<User>> AllUsersAuth()
        {
            var response = userService.GetUsers();

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userNumber")]
        public ActionResult<int> UserNumber()
        {
            return Ok(userService.GetUsersNumber());
        }

    }
}
