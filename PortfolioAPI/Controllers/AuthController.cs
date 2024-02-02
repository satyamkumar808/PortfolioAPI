using BLL.Service_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserModel>> Login([FromBody] UserLoginModel userLogin)
        {
            UserModel authenticatedUser=null;
            try
            {
                authenticatedUser = await this._userService.Login(userLogin);
                if(authenticatedUser == null)
                {
                    return Unauthorized(authenticatedUser);
                }
                return Ok(authenticatedUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
