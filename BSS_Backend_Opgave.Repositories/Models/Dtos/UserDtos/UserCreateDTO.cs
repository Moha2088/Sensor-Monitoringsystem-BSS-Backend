
namespace BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos
{
    public class UserCreateDTO
    {
        public string Name { get; set; } = null!;
        
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
