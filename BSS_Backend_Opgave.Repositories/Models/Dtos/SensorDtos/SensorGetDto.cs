
namespace BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos
{
    public class SensorGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
