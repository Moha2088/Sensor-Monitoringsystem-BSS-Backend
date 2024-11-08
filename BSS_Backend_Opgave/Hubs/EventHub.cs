using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BSS_Backend_Opgave.API.Hubs;

public sealed class EventHub : Hub<IEventHubClient>
{
    private readonly IAuthenticationService _authenticationService;

    public EventHub(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.ReceiveMessage($"You've ({Context.ConnectionId}) joined at: {DateTime.Now:HH:mm:ss}!");
    }

    public async Task JoinGroup()
    {
        int? userOrgIdClaim = null;
        var token = Context.GetHttpContext()!.Request.Headers.SingleOrDefault(x => x.Key.Equals("Token")).Value;
        userOrgIdClaim = _authenticationService.GetOrganisationIdClaim(token: token!);
        var groupName = $"Group {userOrgIdClaim}";
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName: groupName);
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