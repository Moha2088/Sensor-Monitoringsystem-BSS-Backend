namespace BSS_Backend_Opgave.Models;

public class EventLog
{
    public int Id { get; set; }
    
    public DateTimeOffset EventTime { get; set; }

    public State? State { get; set; }

    public int SensorId { get; set; }
    
    public Sensor Sensor { get; set; }
    
    
}