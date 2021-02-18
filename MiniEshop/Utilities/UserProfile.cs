using AutoMapper;
using MiniEshop.Database.Entities;
using MiniEshop.Models;

namespace MiniEshop.Utilities
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
