using Asp.Versioning;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BSS_Backend_Opgave.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserDto dto)
        {
            var result = await _authService.AuthenticateUser(dto);
            return result != null ? Ok(result) : Unauthorized("User does not exist!");
        }
    }
}
