namespace BSS_Backend_Opgave.Models;

public class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int EventLogId { get; set; }

    public EventLog EventLog { get; set; } = null!;
}