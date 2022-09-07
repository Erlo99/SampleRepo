using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Exceptions;
using Domain.Entities.Users;
using Domain.Http.User;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands;

public class UpdateUserCommand
{
    public class Validator : AbstractValidator<UpdateUserCommandRequest>
    {
        public Validator() : base()
        {

        }
    }

    public class Handler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException();

            entity = _mapper.Map<User>(request);

            var user = await _userRepository.UpdateUserAsync(entity, cancellationToken);

            return _mapper.Map<UpdateUserCommandResponse>(user);
        }
    }
}