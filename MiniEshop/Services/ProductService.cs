using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Database.Entities;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Repositories.Interfaces;
using MiniEshop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IHttpContextAccessor httpContext,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _httpContext = httpContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreateProduct request)
        {
            var entity = new Product
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
            
            await _productRepository.AddAsync(entity);
            var rq = _httpContext.HttpContext.Request;
            var product = _mapper.Map<ProductDto>(entity);
            return new CreatedResult(new Uri($"{rq.Scheme}://{rq.Host}/api/products/{entity.Id}"), product);
        }

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var entities = await _productRepository.GetAllProductsAsync();
            var products = _mapper.Map<List<ProductDto>>(entities);
            return products;
        }

        public async Task<ActionResult<ProductDto>> GetProductAsync(int productId)
        {
            var entity = await _productRepository.GetProductAsync(productId);
            return _mapper.Map<ProductDto>(entity);
        }
    }
}
