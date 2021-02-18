using Microsoft.EntityFrameworkCore;
using MiniEshop.Database;
using MiniEshop.Database.Entities;
using MiniEshop.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductAsync(int productId)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == productId);
        }
        public async Task UpdateProductAsync(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
