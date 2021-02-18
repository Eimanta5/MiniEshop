using MiniEshop.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartAsync(int shoppingCartId);
        Task<List<Product>> GetShoppingCartProductsAsync(int shoppingCartId);
        Task AddShoppingCartProductAsync(ShoppingCart shoppingCart, Product product, int quantity);
        Task RemoveShoppingCartProductAsync(ShoppingCart shoppingCart, Product product);
        Task<ShoppingCart> GetActiveShoppingCartAsync(int userId);
        Task UpdateShoppingCartAsync(ShoppingCart entity);
        Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart entity);
        Task<bool> IsProductInCart(int shoppingCartId, int productId);
    }
}
