using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace BSS_Backend_Opgave.Services.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOptionsMonitor<JwtBearerOptions> _jwtOptions;
        private readonly BSS_Backend_OpgaveAPIContext _context;

        public AuthenticationService(IOptionsMonitor<JwtBearerOptions> jwtOptions, BSS_Backend_OpgaveAPIContext context)
        {
            _jwtOptions = jwtOptions;
            _context = context;
        }

        public async Task<string> AuthenticateUser(AuthenticateUserDto dto)
        {
            if (_context.User.Any(user => user.Name.Equals(dto.Name) && user.Password.Equals(dto.Password))) 
            {
                var user = await _context.User.SingleOrDefaultAsync(user => user.Name.Equals(dto.Name) && user.Password.Equals(dto.Password));
                return GenerateToken(user!);
            }

            return null;
        }

        public string GenerateToken(User user)
        {
            var options = _jwtOptions.Get(JwtBearerDefaults.AuthenticationScheme);
            var issuerSigningKey = options.TokenValidationParameters.IssuerSigningKey;
            var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: options.ClaimsIssuer,
                audience: options.Audience,
                claims: new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("organisationId", user.OrganisationId.ToString() ??
                                            throw new ArgumentException("Missing OrganisationId!"))
                },
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
