using AutoMapper;
using MiniEshop.Database.Entities;
using MiniEshop.Models;

namespace MiniEshop.Utilities
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>()
                .ForMember(x => x.ShoppingCartId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
