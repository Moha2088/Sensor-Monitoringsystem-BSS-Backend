

namespace BSS_Backend_Opgave.Models;

public class SensorCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Sensor> Sensors { get; set; }
}