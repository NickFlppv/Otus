using AutoMapper;
using Otus.Domain.Cities;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;
using Otus.Postgres.Dtos;

namespace Otus.Service.Mapping;

public class PostgresMappingProfile : Profile
{
    public PostgresMappingProfile()
    {
        CreateMap<CityDto, City>();
        CreateMap<GenderDto, Gender>();
        CreateMap<UserInterestDto, UserInterest>();
        CreateMap<UserCardDto, UserCard>();
    }
}