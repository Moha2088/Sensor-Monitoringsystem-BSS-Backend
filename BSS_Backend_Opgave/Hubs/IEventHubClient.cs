using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.API.Hubs;

public interface IEventHubClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task ReceiveMessage(string message);

    /// <summary>
    /// Sends information about the sensor which state has changed
    /// </summary>
    /// <param name="id">The dto that contains information about the event</param>
    /// <returns></returns>
    public Task OnStateChanged(string dtoJson);
}