using Microsoft.EntityFrameworkCore;
using MiniEshop.Database;
using MiniEshop.Database.Entities;
using MiniEshop.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEshop.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShoppingCartRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart entity)
        {
            await _databaseContext.ShoppingCarts.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddShoppingCartProductAsync(ShoppingCart shoppingCart, Product product, int quantity)
        {
            var entity = new ShoppingCartProduct
            {
                Product = product,
                ShoppingCart = shoppingCart,
                Quantity = quantity,
                PriceWhenAdded = product.Price
            };

            await _databaseContext.ShoppingCartProducts.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetActiveShoppingCartAsync(int userId)
        {
            return await _databaseContext.ShoppingCarts
                .SingleOrDefaultAsync(x => x.UserId == userId && x.IsActive == true);
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(int shoppingCartId)
        {
            return await _databaseContext.ShoppingCarts.SingleOrDefaultAsync(x => x.Id == shoppingCartId);
        }

        public async Task RemoveShoppingCartProductAsync(ShoppingCart shoppingCart, Product product)
        {
            var entity = await _databaseContext.ShoppingCartProducts
                .Where(x => x.ProductId == product.Id && x.ShoppingCartId == shoppingCart.Id).SingleOrDefaultAsync();

            _databaseContext.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetShoppingCartProductsAsync(int shoppingCartId)
        {
            return await _databaseContext.ShoppingCartProducts
               .Where(x => x.ShoppingCartId == shoppingCartId)
               .Include(x => x.Product)
               .Select(x => x.Product)
               .ToListAsync();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart entity)
        {
            _databaseContext.ShoppingCarts.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<bool> IsProductInCart(int shoppingCartId, int productId)
        {
            return await _databaseContext.ShoppingCartProducts
                .AnyAsync(x => x.ProductId == productId && x.ShoppingCartId == shoppingCartId);
        }
    }
}
