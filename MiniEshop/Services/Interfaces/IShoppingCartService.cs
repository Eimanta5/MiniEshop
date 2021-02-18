using Microsoft.AspNetCore.Mvc;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ActionResult<ShoppingCartDto>> GetActiveShoppingCartAsync(int userId);
        Task<ActionResult> AddProductToShoppingCartAsync(AddProductToShoppingCart request, int userId);
        Task<ActionResult> RemoveProductFromShoppingCartAsync(RemoveProductFromShoppingCart request, int userId);
        Task<ActionResult<IEnumerable<ProductDto>>> GetActiveCartProductsAsync(int userId, int shoppingCarId);
    }
}
