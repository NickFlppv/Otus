using AutoMapper;
using Otus.Contracts;
using Otus.Domain.Cities;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;

namespace Otus.Service.Mapping;

public class ResponsesMappingProfile : Profile
{
    public ResponsesMappingProfile()
    {
        CreateMap<City, CityResponse>();
        CreateMap<Gender, GenderResponse>();
        CreateMap<UserInterest, UserInterestResponse>();
        CreateMap<UserCard, UserCardResponse>();
    }
}