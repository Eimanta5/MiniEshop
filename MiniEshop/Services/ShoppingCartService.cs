using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Repositories.Interfaces;
using MiniEshop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartService(
            IShoppingCartRepository cartRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> AddProductToShoppingCartAsync(AddProductToShoppingCart request, int userId)
        {
            var shoppingCart = await _cartRepository.GetShoppingCartAsync(request.ShoppingCartId);
            if (shoppingCart.UserId != userId)
                return new UnauthorizedResult();

            if (!shoppingCart.IsActive)
                throw new Exception("Shopping Cart is not active.");

            var product = await _productRepository.GetProductAsync(request.ProductId);

            if (product.Quantity < request.Quantity)
                throw new Exception("Not enough items");

            var exists = await _cartRepository.IsProductInCart(shoppingCart.Id, product.Id);
            if (exists)
                throw new Exception("Can't add same products in the same cart");

            await _cartRepository.AddShoppingCartProductAsync(shoppingCart, product, request.Quantity);
            return new NoContentResult();
        }

        public Task<ActionResult<ShoppingCartDto>> CompletePurshaceAsync(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ShoppingCartDto>> GetActiveShoppingCartAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetActiveCartProductsAsync(int userId, int shoppingCarId)
        {
            var shoppingCart = await _cartRepository.GetShoppingCartAsync(shoppingCarId);
            if (shoppingCart.UserId != userId)
                return new UnauthorizedResult();

            var entities = await _cartRepository.GetShoppingCartProductsAsync(shoppingCarId);
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<ActionResult> RemoveProductFromShoppingCartAsync(RemoveProductFromShoppingCart request, int userId)
        {
            var shoppingCart = await _cartRepository.GetShoppingCartAsync(request.ShoppingCartId);
            if (shoppingCart.UserId != userId)
                return new UnauthorizedResult();

            if (!shoppingCart.IsActive)
                throw new Exception("Shopping Cart is not active.");

            var product = await _productRepository.GetProductAsync(request.ProductId);

            await _cartRepository.RemoveShoppingCartProductAsync(shoppingCart, product);
            return new NoContentResult();
        }
    }
}
