using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Authentication;
using Application.Interfaces;
using CoNettion.Core.Exceptions;
using Domain.Entities.Users;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Authentication
{
    public class Validator : AbstractValidator<AuthenticationRequest>
    {
        public Validator() : base()
        {

        }
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _userRepository = userRepository;
        }

        public async Task<string> Authenticate(AuthenticationRequest request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.UserName);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UserName}"),
                new Claim(ClaimTypes.Role, $"{user.RoleId}"),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
