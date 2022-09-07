using Domain.Entities.Users;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Dto.Authentication
{
    public class AuthenticationRequest : IRequest<AuthenticationResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
