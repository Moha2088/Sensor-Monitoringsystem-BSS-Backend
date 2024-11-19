using System.Security.Claims;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSS_Backend_Opgave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;


        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }


        [HttpGet("updateState")]
        public async Task<IActionResult> UpdateState()
        {
            var result = await _eventLogService.UpdateState();
            return Ok(result);
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
