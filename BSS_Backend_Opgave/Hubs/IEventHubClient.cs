
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
    /// Notifies a group about a change in their sensors state
    /// </summary>
    /// <param name="eventLog">An eventlog that contains information about a sensor and it's state</param>
    /// <returns></returns>
    public Task NotifyStateChange(string eventLog);
}