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
        CreateMap<UserRequest, User>();
        CreateMap<UserCardRequest, UserCard>();
    }
}