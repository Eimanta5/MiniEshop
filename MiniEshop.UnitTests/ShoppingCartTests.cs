using AutoMapper;
using FakeItEasy;
using MiniEshop.Database.Entities;
using MiniEshop.Models.Actions;
using MiniEshop.Repositories.Interfaces;
using MiniEshop.Services;
using MiniEshop.Utilities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MiniEshop.UnitTests
{
    public class ShoppingCartTests
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCartService _cartService;

        public ShoppingCartTests()
        {
            _cartRepository = A.Fake<IShoppingCartRepository>();
            _productRepository = A.Fake<IProductRepository>();
            var mapper = new Mapper(
                new MapperConfiguration(
                    configure =>
                    {
                        configure.AddProfile<ShoppingCartProfile>();
                    }));
            _cartService = new ShoppingCartService(_cartRepository, _productRepository, mapper);
        }

        [Fact]
        public async Task AddProductToShoppingCartAsync_ValidProduct_AddedProduct()
        {
            var userId = 1;
            var shoppingCartId = 2;
            var productId = 3;

            var request = new AddProductToShoppingCart
            {
                ProductId = productId,
                Quantity = 5,
                ShoppingCartId = shoppingCartId,
            };

            var cartEntity = new ShoppingCart
            {
                Id = shoppingCartId,
                IsActive = true,
                UserId = userId
            };

            var productEntity = new Product
            {
                Id = productId,
                Description = "Test_Description",
                Name = "Test_Name",
                Price = 2.56,
                Quantity = 100
            };

            var callToGetShoppingCart = A.CallTo(() => _cartRepository.GetShoppingCartAsync(shoppingCartId));
            callToGetShoppingCart.Returns(cartEntity);

            var callToGetProduct = A.CallTo(() => _productRepository.GetProductAsync(productId));
            callToGetProduct.Returns(productEntity);

            var callToAddProduct = A.CallTo(() => _cartRepository.AddShoppingCartProductAsync(cartEntity, productEntity, request.Quantity));

            await _cartService.AddProductToShoppingCartAsync(request, userId);

            callToGetShoppingCart.MustHaveHappenedOnceExactly();
            callToGetProduct.MustHaveHappenedOnceExactly();
            callToAddProduct.MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task AddProductToShoppingCartAsync_NotActiveCart_ThrowsException()
        {
            var userId = 1;
            var shoppingCartId = 2;
            var productId = 3;

            var request = new AddProductToShoppingCart
            {
                ProductId = productId,
                Quantity = 5,
                ShoppingCartId = shoppingCartId
            };

            var cartEntity = new ShoppingCart
            {
                Id = shoppingCartId,
                IsActive = false,
                UserId = userId
            };

            var callToGetShoppingCart = A.CallTo(() => _cartRepository.GetShoppingCartAsync(shoppingCartId));
            callToGetShoppingCart.Returns(cartEntity);

            Exception ex = await Assert.ThrowsAsync<Exception>(() => _cartService.AddProductToShoppingCartAsync(request, userId));
            Assert.Equal("Shopping Cart is not active.", ex.Message);

            callToGetShoppingCart.MustHaveHappenedOnceExactly();
        }
    }
}
