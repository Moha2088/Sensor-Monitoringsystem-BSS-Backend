using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace BSS_Backend_Opgave.API.Hubs;

[Microsoft.AspNet.SignalR.Authorize]
public sealed class EventHub : Hub<IEventHubClient>
{
    public override async Task OnConnectedAsync()
    {
        int.TryParse(Context.User!.FindFirstValue("organisationId"), out var organisationId);
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName: organisationId.ToString());
        await Clients.Group(organisationId.ToString()).ReceiveMessage($"Id: {Context.ConnectionId} has joined group: {organisationId} at {DateTime.Now:HH:mm:ss}");
    }

    public override async Task OnDisconnectedAsync(Exception? e)
    {
        Console.WriteLine($"{Context.ConnectionId} has disconnected at: {DateTime.Now:HH:mm:ss}!");
        await base.OnDisconnectedAsync(e);
    }
}