using Microsoft.AspNetCore.SignalR;

namespace BSS_Backend_Opgave.API.Hubs;

public sealed class EventHub : Hub<IEventHubClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.ReceiveMessage($"You've ({Context.ConnectionId}) joined at: {DateTime.Now:HH:mm:ss}!");
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Task.Delay(5000);
        await Clients.Groups(groupName).ReceiveMessage($"User: {Context.ConnectionId} has joined room: {groupName} at {DateTime.Now:HH:mm:ss}");
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await Clients.Caller.ReceiveMessage($"You have left room: {groupName} at {DateTime.Now}");
    }

    public override async Task OnDisconnectedAsync(Exception? e)
    {
        Console.WriteLine($"{Context.ConnectionId} has disconnected at: {DateTime.Now:HH:mm:ss}!");
        await base.OnDisconnectedAsync(e);
    }
}