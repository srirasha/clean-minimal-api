using AutoMapper;
using Domain.Assets;
using Infrastructure.Persistence.Contexts.AssetsDb.Entities;

namespace Infrastructure.Mapping
{
    public class AvatarProfile : Profile
    {
        public AvatarProfile()
        {
            CreateMap<AvatarDocument, Avatar>().ForMember(dest => dest.Id,
                                                          options => options.MapFrom(src => src.Id));
        }
    }
}