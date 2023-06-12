using AutoMapper;
using Otus.Contracts;
using Otus.Contracts.Requests;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;
using Otus.Domain.Users;

namespace Otus.Service.Mapping;

public class RequestsMappingProfile : Profile
{
    public RequestsMappingProfile()
    {
        CreateMap<GenderRequest, Gender>();
        CreateMap<UserCardRequest, UserCard>();
        CreateMap<UserRequest, User>()
            .ForMember(u => u.UserCard, 
            config => config.MapFrom(e => e.UserCard));
    }
}