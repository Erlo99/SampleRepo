using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Enums;
using Domain.Entities.Users;
using Domain.Http.User;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;

public class CreateUserCommand
{
    public class Validator : AbstractValidator<CreateUserCommandRequest>
    {
        public Validator() : base()
        {
            
        }
    }

    public class Handler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public Handler(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var enitity = _mapper.Map<User>(request);
            enitity.HashedPassword = _passwordHasher.HashPassword(enitity, request.Password);

            var user = await _userRepository.AddUserAsync(enitity, cancellationToken);

            return _mapper.Map<CreateUserCommandResponse>(user);
        }
    }
} 