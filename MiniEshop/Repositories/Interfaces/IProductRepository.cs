using MiniEshop.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductAsync(int productId);
        public Task UpdateProductAsync(Product entity);
        public Task<Product> AddAsync(Product entity);
    }
}
