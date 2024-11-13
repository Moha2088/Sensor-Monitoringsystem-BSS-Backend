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
using Microsoft.Extensions.Configuration;

namespace BSS_Backend_Opgave.Services.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly BSS_Backend_OpgaveAPIContext _context;

        public AuthenticationService(BSS_Backend_OpgaveAPIContext context)
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _context = context;
        }

        public async Task<string> AuthenticateUser(AuthenticateUserDto dto)
        {
            if (_context.User.Any(user => user.Email.Equals(dto.Email) && user.Password.Equals(dto.Password))) 
            {
                var user = await _context.User.SingleOrDefaultAsync(user => user.Email.Equals(dto.Email) && user.Password.Equals(dto.Password));
                return GenerateToken(user!);
            }

            return null!;
        }

        public string GenerateToken(User user)
        {
            var issuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_config["JWTSettings:Key"]));
            var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: _config["JWTSettings:Issuer"],
                audience: _config["JWTSettings:Audience"],
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

        public int? GetOrganisationIdClaim(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var principal = jwtSecurityToken.Claims.SingleOrDefault(x => x.Type.Equals("organisationId"));
            return Convert.ToInt32(principal?.Value);
        }

       
    }
}
