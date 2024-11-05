using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UserCreateDTO dto, CancellationToken cancellationToken);
        Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken);
        Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);
    }
}
