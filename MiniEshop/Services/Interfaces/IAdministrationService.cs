using MiniEshop.Models.Actions;

namespace MiniEshop.Services.Interfaces
{
    interface IAdministrationService
    {
        void AddProduct(CreateProduct request);
        void UpdateProduct(CreateProduct request);
    }
}
