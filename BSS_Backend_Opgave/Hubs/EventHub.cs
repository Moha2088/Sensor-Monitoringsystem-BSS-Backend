using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using Microsoft.AspNetCore.Authorization;

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