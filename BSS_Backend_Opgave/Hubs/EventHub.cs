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
    public static int? AuthenticatedUserOrgId { get; set; }

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName: AuthenticatedUserOrgId.ToString()!);
        await Clients.Caller.ReceiveMessage($"You've joined at: {DateTime.Now:HH:mm:ss} and joined group: {AuthenticatedUserOrgId.ToString()!}");
    }

    public override async Task OnDisconnectedAsync(Exception? e)
    {
        Console.WriteLine($"{Context.ConnectionId} has disconnected at: {DateTime.Now:HH:mm:ss}!");
        await base.OnDisconnectedAsync(e);
    }
}