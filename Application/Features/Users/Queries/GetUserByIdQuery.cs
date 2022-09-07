using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Exceptions;
using Domain.Http.User;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserByIdQuery
{
    public class Handler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);
            
            if (user == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<GetUserByIdQueryResponse>(user);
        }
    }
}