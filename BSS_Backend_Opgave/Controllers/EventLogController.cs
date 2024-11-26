using System.Security.Claims;
using System.Text.Json;
using BSS_Backend_Opgave.API.Hubs;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BSS_Backend_Opgave.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;
        private readonly IHubContext<EventHub, IEventHubClient> _eventHub;


        public EventLogController(IEventLogService eventLogService, IHubContext<EventHub, IEventHubClient> eventHub)
        {
            _eventLogService = eventLogService;
            _eventHub = eventHub;
        }


        /// <summary>
        /// Updates a sensor's state and notifies the organisation's user(s)
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        [HttpGet("updateState/{sensorId}")]
        public async Task<IActionResult> UpdateState([FromRoute] int sensorId)
        {
            int.TryParse(HttpContext.User.FindFirstValue("organisationId"), out var organisationId);

            try
            {
                var result = await _eventLogService.UpdateState(sensorId);
                var serializedDto = JsonSerializer.Serialize(result);
                await _eventHub.Clients.Group(organisationId.ToString()).ReceiveMessage(serializedDto);
            }

            catch (NullReferenceException)
            {
                return NotFound("Sensor does not exist!");
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetEventLogs(CancellationToken cancellationToken)
        {
            int.TryParse(HttpContext.User.FindFirstValue("organisationId"), out var organisationId);
            var result = await _eventLogService.GetEventLogs(organisationId, cancellationToken);
            return Ok(result);
        }
    }
}
