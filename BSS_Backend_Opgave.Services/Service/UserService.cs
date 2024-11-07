using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;



        public async Task<UserGetDto> CreateUser(UserCreateDTO dto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CreateUser(dto, cancellationToken);
            return user;
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(id, cancellationToken);
        }

        public async Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(id, cancellationToken);
            return user;
        }

        public async Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers(cancellationToken);
            return users;
        }
    }
}
