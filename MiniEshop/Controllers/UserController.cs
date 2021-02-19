using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Constants;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace MiniEshop.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("api/users/{userId}")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<UserDto>> GetUserAsync(int userId)
        {
            return await _userService.GetUserInfo(userId);
        }

        
    }
}
