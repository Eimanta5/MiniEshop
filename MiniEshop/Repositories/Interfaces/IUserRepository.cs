using MiniEshop.Database.Entities;
using System.Threading.Tasks;

namespace MiniEshop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User entity);
        public Task<User> UpdateUserAsync(User entity);
        public Task<User> GetUserByIdAsync(int userId);
        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
