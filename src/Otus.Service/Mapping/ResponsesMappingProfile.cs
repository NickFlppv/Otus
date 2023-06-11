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
        CreateMap<UserCard, UserCardResponse>();
        CreateMap<User, UserCardResponse>();
    }
}