

namespace BSS_Backend_Opgave.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Location { get; set; }

        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; } = null!;
    }
}
