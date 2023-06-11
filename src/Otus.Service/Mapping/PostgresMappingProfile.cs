using AutoMapper;
using Otus.Domain.Genders;
using Otus.Domain.UserCards;
using Otus.Domain.Users;
using Otus.Postgres.Dtos;

namespace Otus.Service.Mapping;

public class PostgresMappingProfile : Profile
{
    public PostgresMappingProfile()
    {
        CreateMap<GenderDto, Gender>();
        CreateMap<UserCardDto, UserCard>();
        CreateMap<UserDto, User>();

        CreateMap<Gender, GenderDto>();
        CreateMap<UserCard, UserCardDto>();
        CreateMap<User, UserDto>();
        
    }
}