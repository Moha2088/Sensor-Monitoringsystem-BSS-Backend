using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDto> CreateUser(UserCreateDTO dto, int organisationId, CancellationToken cancellationToken);
        Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken);
        Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);
    }
}
