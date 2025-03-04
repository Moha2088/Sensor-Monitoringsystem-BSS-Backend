﻿using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;


        ///<see cref="IUserService.CreateUser(UserCreateDTO, int, CancellationToken)"/>
        public async Task<UserGetDto> CreateUser(UserCreateDTO dto, int organisationId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CreateUser(dto, organisationId, cancellationToken);
            return user;
        }

        ///<see cref="IUserService.DeleteUser(int, CancellationToken)"/>
        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(id, cancellationToken);
        }

        ///<see cref="IUserService.GetUser(int, CancellationToken)"/>
        public async Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(id, cancellationToken);
            return user;
        }
        
        ///<see cref="IUserService.GetUsers(CancellationToken)"/>
        public async Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers(cancellationToken);
            return users;
        }
    }
}
