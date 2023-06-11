using AutoMapper;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;
using Otus.Postgres.Dtos;

namespace Otus.Service.Mapping;

public class PostgresMappingProfile : Profile
{
    public PostgresMappingProfile()
    {
        CreateMap<GenderDto, Gender>();
        CreateMap<UserCardDto, UserCard>();
    }
}