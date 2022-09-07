using Application.Interfaces;
using AutoMapper;
using Domain.Http.User;
using MediatR;

namespace Application.Features.Users.Commands;

public class DeleteUserCommand
{
    public class Handler : IRequestHandler<DeleteUserCommandRequest, Unit>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);

            if (entity == null) 
                return default;

            return await _userRepository.DeleteUserAsync(entity, cancellationToken);
        }
    }
} 