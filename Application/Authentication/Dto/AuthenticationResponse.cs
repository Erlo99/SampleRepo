using Domain.Entities.Users;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Dto.Authentication
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
    }
}
