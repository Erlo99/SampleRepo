using Application.Dto.Authentication;
using AutoMapper;
using Domain.Entities.Users;
using Domain.Http.User;

namespace Application.Features.Users;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, GetUserByIdQueryResponse>();

        CreateMap<IQueryable<User>, GetUserListQueryResponse>();

        CreateMap<AuthenticationRequest, User>();

        CreateMap<UpdateUserCommandRequest, User>();

        CreateMap<CreateUserCommandRequest, User>();

        CreateMap<User, CreateUserCommandResponse>();

        CreateMap<User, UpdateUserCommandResponse>();

    }
}