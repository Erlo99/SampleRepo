using Application.Interfaces;
using AutoMapper;
using CoNettion.Core.Exceptions;
using Domain.Http.User;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserListQuery
{
    public class Handler : IRequestHandler<GetUserListQueryRequest, GetUserListQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserListQueryResponse> Handle(GetUserListQueryRequest request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetUserListAsync(null, null, cancellationToken);
            
            if (userList == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<GetUserListQueryResponse>(userList);
        }
    }
}