using AutoMapper;
using Otus.Contracts;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;
using Otus.Domain.Users;

namespace Otus.Service.Mapping;

public class ResponsesMappingProfile : Profile
{
    public ResponsesMappingProfile()
    {
        CreateMap<Gender, GenderResponse>();
        CreateMap<UserCard, UserCardResponse>()
            .ForMember(uc => uc.Gender, config =>
                config.MapFrom(e => e.Gender));
        CreateMap<User, UserResponse>()
            .ForMember(u => u.UserCard, config => 
                config.MapFrom(e => e.UserCard));
    }
}