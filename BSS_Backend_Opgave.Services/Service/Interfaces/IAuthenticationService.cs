﻿using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="dto">Data to authenticate a user</param>
        /// <returns>A token if the user exists</returns>
        public Task<AuthenticateUserGetDto> AuthenticateUser(AuthenticateUserDto dto);

        /// <summary>
        /// Generates a JWT Token
        /// </summary>
        /// <param name="user">The user to which the token is generated for</param>
        /// <returns>A A JWT token</returns>
        public string GenerateToken(User user);

        public Task<bool> IsViewable(int sensorId, int organisationId);
    }
}
