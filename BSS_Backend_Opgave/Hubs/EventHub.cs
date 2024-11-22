using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.API.Hubs;

public sealed class EventHub : Hub<IEventHubClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.ReceiveMessage($"You've ({Context.ConnectionId}) joined at: {DateTime.Now:HH:mm:ss}!");
    }

    public async Task JoinGroup()
    {
        var userOrgIdClaim = Context.GetHttpContext()!.User.FindFirstValue("organisationId");
        var groupName = userOrgIdClaim;
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName: groupName!);
        await Clients.Groups(groupName!).ReceiveMessage($"User: {Context.ConnectionId} has joined room: {groupName} at {DateTime.Now:HH:mm:ss}");
    }
    
    //public async Task LeaveGroup()
    //{
    //    int? userOrgIdClaim = _authenticationService.GetOrganisationIdClaim();
    //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, userOrgIdClaim.ToString()!);
    //    await Clients.Caller.ReceiveMessage($"You have left room: {userOrgIdClaim.ToString()} at {DateTime.Now}");
    //}

    public override async Task OnDisconnectedAsync(Exception? e)
    {
        Console.WriteLine($"{Context.ConnectionId} has disconnected at: {DateTime.Now:HH:mm:ss}!");
        await base.OnDisconnectedAsync(e);
    }
}