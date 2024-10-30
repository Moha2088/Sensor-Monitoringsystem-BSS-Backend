using Microsoft.AspNetCore.SignalR;

namespace BSS_Backend_Opgave.API.Hubs;

public sealed class EventHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined!");
    }
}