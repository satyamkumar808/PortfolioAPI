using BLL.Service_Interface;
using DAL.DB_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace PortfolioAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Profile/{userEmail}")]
        public async Task<IActionResult> GetProfile([FromRoute] string userEmail)
        {
            UserProfile userProfile;
            User user = await this._userService.GetUserByEmail(userEmail);
            if(user != null) 
            {
                userProfile = new UserProfile
                {
                    Id = user.Id,
                    UserEmail = user.UserEmail,
                    UserName = user.UserName
                };
                return Ok(userProfile);
            }
            return NotFound(userEmail);
        }
    }
}
