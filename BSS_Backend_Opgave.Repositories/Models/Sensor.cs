

namespace BSS_Backend_Opgave.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; }

        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; } = null!;

        public SensorCategory? SensorCategory { get; set; }

        public int? SensorCategoryId { get; set; }

        public State? State { get; set; }
        
        public ICollection<EventLog> EventLogs { get; set; }
    }
}
