using Microsoft.AspNetCore.Mvc;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniEshop.Services.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<ActionResult<ProductDto>> GetProductAsync(int productId);
        Task<ActionResult<ProductDto>> CreateProductAsync(CreateProduct request);
    }
}
