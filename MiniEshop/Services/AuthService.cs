using MiniEshop.Database.Entities;
using MiniEshop.Repositories.Interfaces;
using MiniEshop.Services.Interfaces;
using System.Threading.Tasks;

namespace MiniEshop.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPasswordAsync(email.ToLower(), password);
        }
    }
}
