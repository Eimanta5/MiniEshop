using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Constants;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MiniEshop.Controllers
{
    [Authorize]
    public class ShoppingCartController : ApiController
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("api/shoppingCart/{shoppingCartId}/products")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetActiveCartProducts(int shoppingCartId)
        {
            var userId = GetUserId();
            return await _cartService.GetActiveCartProductsAsync(userId, shoppingCartId);
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("api/shoppingCart/products")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> AddProducts([FromBody]AddProductToShoppingCart request)
        {
            var userId = GetUserId();
            return await _cartService.AddProductToShoppingCartAsync(request, userId);
        }

        [Authorize(Roles = Roles.User)]
        [HttpDelete("api/shoppingCart/products")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> RemoveProduct([FromBody] RemoveProductFromShoppingCart request)
        {
            var userId = GetUserId();
            return await _cartService.RemoveProductFromShoppingCartAsync(request, userId);
        }
    }
}
