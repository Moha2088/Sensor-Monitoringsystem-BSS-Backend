using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BSS_Backend_Opgave.API.Controllers
{
    [Authorize]
    [Route("api/sensors")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }
        
 
        /// <summary>
        /// Creates a sensor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///      POST /sensors
        ///      {
        ///         "name": "SensorName",
        ///         "location": "SensorLocation"
        ///      }
        /// 
        /// 
        /// </remarks>
        /// <param name="dto">Data to create a sensor</param>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <response code="201">Returns created when sensor has been created</response>>
        [HttpPost]
        [ProducesResponseType(typeof(SensorGetDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSensor([FromBody] SensorCreateDto dto, CancellationToken cancellationToken)
        {
            int.TryParse(HttpContext.User.FindFirstValue("organisationId"), out var organisationId);

            var result = await _sensorService.CreateSensor(dto, organisationId, cancellationToken);
            return Created(nameof(CreateSensor), result);
        }

        /// <summary>
        /// Gets a sensor
        /// </summary>
        /// <param name="id">Id of the sensor</param>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <response code="200">Returns OK with the user if the user exists</response>
        /// <response code="404">Returns NotFound if the user doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SensorGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSensor([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _sensorService.GetSensor(id, cancellationToken);
            return result != null ? Ok(result) : NotFound("User doesn't exist");
        }

        /// <summary>
        /// Gets a list of sensors
        /// </summary>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <response code= "200">Returns OK íf the list isn't empty</response>
        /// <response code= "404">Returns NotFound íf the list is empty</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SensorGetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSensors(CancellationToken cancellationToken)
        {
            int.TryParse(HttpContext.User.FindFirstValue("organisationId"), out var organisationId);
            var results = await _sensorService.GetSensors(organisationId, cancellationToken);
            return results.Any() ? Ok(results) : NotFound();
        }

        /// <summary>
        /// Deletes a sensor
        /// </summary>
        /// <param name="id">Id of the sensor</param>
        /// <param name="cancellationToken">A cancellation token for cancelling requests</param>
        /// <response code= "204">Returns NoContent</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteSensor([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _sensorService.DeleteSensor(id, cancellationToken);
            return NoContent();
        }
    }
}
