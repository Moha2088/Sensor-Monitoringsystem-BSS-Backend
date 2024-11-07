using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDto> CreateUser(UserCreateDTO dto, CancellationToken cancellationToken);
        Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken);
        Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);
    }
}
