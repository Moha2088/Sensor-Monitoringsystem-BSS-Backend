using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BSS_Backend_Opgave.API.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class OrganisationsController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;

        public OrganisationsController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        /// <summary>
        /// Creates an Organisation
        /// </summary>
        /// <param name="dto">Data to create an Organisation</param>
        /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
        /// <response code="201">Returns created when an organisation has been created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOrganisation([FromBody] OrganisationCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _organisationService.CreateOrganisation(dto, cancellationToken);
            return Created(nameof(CreateOrganisation), result);
        }

        /// <summary>
        /// Gets an organisation
        /// </summary>
        /// <param name="id">Id of the organisation</param>
        /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
        /// <response code="200">Returns OK with the organisation</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganisation([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _organisationService.GetOrganisation(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Gets a list of Organisations
        /// </summary>
        /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
        /// <response code="200">Returns OK with the organisation</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetOrganisations(CancellationToken cancellationToken)
        {
            var results = await _organisationService.GetOrganisations(cancellationToken);
            return Ok(results);
        }

        /// <summary>
        /// Deletes an Organisation
        /// </summary>
        /// <param name="id">Id of the organisation</param>
        /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
        /// <response code="204">Returns NoContent</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteOrganisation([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _organisationService.DeleteOrganisation(id, cancellationToken);
            return NoContent();
        }
    }
}
