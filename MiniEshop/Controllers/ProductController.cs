using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MiniEshop.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("api/products")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet("api/products/{productId}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int productId)
        {
            return await _productService.GetProductAsync(productId);
        }
    }
}
