using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;

namespace BSS_Backend_Opgave.Repositories.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserGetDto> CreateUser(UserCreateDTO dto, int organisationId, CancellationToken cancellationToken);
        Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken);
        Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);
    }
}
