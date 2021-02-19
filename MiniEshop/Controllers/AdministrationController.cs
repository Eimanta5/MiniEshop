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
        private readonly IUserService _userService;

        public AdministrationController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        [Authorize(Roles = Roles.Administration)]
        [HttpPost("api/administration/products")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<ActionResult<ProductDto>> GetAllProduct([FromBody] CreateProduct request)
        {
            return await _productService.CreateProductAsync(request);
        }

        [Authorize(Roles = Roles.Administration)]
        [HttpPost("api/administration/users")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] CreateUser request)
        {
            return await _userService.CreateUserAsync(request);
        }

    }
}
