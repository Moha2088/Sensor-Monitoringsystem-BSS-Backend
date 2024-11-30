using System.Text.Json.Serialization;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos
{
    public class EventLogGetDto
    {
        public int Id { get; set; }

        public DateTimeOffset EventTime { get; set; }

        public string SensorName { get; set; } = null!;

        public string SensorLocation { get; set; } = null!;

        public int SensorId { get; set; }

        public string StateType { get; set; } = null!;

        [JsonIgnore]
        public int OrganisationId { get; set; }
    }
}
