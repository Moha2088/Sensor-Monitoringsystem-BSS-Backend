using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSS_Backend_Opgave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;


        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }


        [HttpGet]
        public async Task<IActionResult> UpdateState()
        {
            var result = await _eventLogService.UpdateState();
            return Ok(result);
        }
    }
}
