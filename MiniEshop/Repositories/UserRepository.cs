using Microsoft.EntityFrameworkCore;
using MiniEshop.Database;
using MiniEshop.Database.Entities;
using MiniEshop.Repositories.Interfaces;
using System.Threading.Tasks;

namespace MiniEshop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<User> AddUserAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> UpdateUserAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
