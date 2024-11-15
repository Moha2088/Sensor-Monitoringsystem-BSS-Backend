namespace BSS_Backend_Opgave.Models;

public class State
{
    public int Id { get; set; }

    public string StateType { get; set; } = null!;

    public int EventLogId { get; set; }

    public EventLog EventLog { get; set; } = null!;

    public Sensor? Sensor { get; set; }

    public int SensorId { get; set; }
}