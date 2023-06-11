using AutoMapper;
using Otus.Contracts;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;

namespace Otus.Service.Mapping;

public class ResponsesMappingProfile : Profile
{
    public ResponsesMappingProfile()
    {
        CreateMap<Gender, GenderResponse>();
        CreateMap<UserCard, UserCardResponse>();
    }
}