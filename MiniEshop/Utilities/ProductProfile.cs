using AutoMapper;
using MiniEshop.Database.Entities;
using MiniEshop.Models;

namespace MiniEshop.Utilities
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
