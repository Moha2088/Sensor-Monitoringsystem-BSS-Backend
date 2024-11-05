

namespace BSS_Backend_Opgave.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; } = null!;

        public ICollection<Sensor>? Sensor {  get; set; } = null!;
    }
}
