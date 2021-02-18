using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Constants;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace MiniEshop.Controllers
{
    [Authorize]
    public class AdministrationController : ApiController
    {
        private readonly IProductService _productService;

        public AdministrationController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = Roles.Administration)]
        [HttpPost("api/products")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<ActionResult<ProductDto>> GetAllProduct([FromBody] CreateProduct request)
        {
            return await _productService.CreateProductAsync(request);
        }
       
    }
}
