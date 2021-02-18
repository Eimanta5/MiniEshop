using Microsoft.AspNetCore.Mvc;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using System.Threading.Tasks;

namespace MiniEshop.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<UserDto>> GetUserInfo(int userId);
        Task<ActionResult<UserDto>> CreateUserAsync(CreateUser request);
    }
}
