using MiniEshop.Database.Entities;
using System.Threading.Tasks;

namespace MiniEshop.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Authenticate(string email, string password);
    }
}
