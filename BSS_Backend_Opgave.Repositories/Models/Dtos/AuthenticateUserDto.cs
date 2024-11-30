
namespace BSS_Backend_Opgave.Repositories.Models.Dtos
{
    public class AuthenticateUserDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
