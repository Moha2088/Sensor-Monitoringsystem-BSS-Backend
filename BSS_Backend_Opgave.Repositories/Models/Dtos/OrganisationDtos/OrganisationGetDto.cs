using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos
{
    public class OrganisationGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<UserGetDto> Users { get; set; } = null!;

        public List<SensorGetDto> Sensors { get; set; } = null!;
    }
}
