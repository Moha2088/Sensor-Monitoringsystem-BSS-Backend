using System.Security.Claims;
using System.Text.Json;
using Asp.Versioning;
using BSS_Backend_Opgave.API.Hubs;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BSS_Backend_Opgave.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
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
            try
            {
                var result = await _eventLogService.UpdateState(sensorId);
                var organisationGroup = result.OrganisationId.ToString();
                var serializedDto = JsonSerializer.Serialize(result);
                await _eventHub.Clients.Group(organisationGroup).NotifyStateChange(serializedDto);
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
