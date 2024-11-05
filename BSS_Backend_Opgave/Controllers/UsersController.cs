using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.API;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;

namespace BSS_Backend_Opgave.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository) => _userRepository = userRepository;

    /// <summary>
    /// Creates a user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /users
    ///     {
    ///        "name": "AUser123",
    ///        "email": "AUser123@gmail.com",
    ///        "password": "APassword123"
    ///     }
    ///
    /// </remarks>
    /// <param name="dto">Data to create a user</param>
    /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
    /// <response code="201">Returns created when user has been created</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO dto, CancellationToken cancellationToken)
    {
        var result = await _userRepository.CreateUser(dto, cancellationToken);
        return Created(nameof(CreateUser), result);
    }

    /// <summary>
    /// Gets a user
    /// </summary>
    /// <param name="id">Id of the user</param>
    /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
    /// <response code="200">Returns Ok with the user if the user exists</response>
    /// <response code="404">Returns NotFound if the user doesn't exists</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetUser(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets a list of users
    /// </summary>
    /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
    /// <response code ="200">Returns OK with the users</response>
    /// <response code ="404">Returns NotFound if no users exist</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var results = await _userRepository.GetUsers(cancellationToken);

        if (!results.Any())
        {
            return NotFound("No users exists!");
        }

        return Ok(results);
    }

    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="id">Id of the user</param>
    /// <param name="cancellationToken">A cancellationToken for cancelling requests</param>
    /// <response code ="204">Returns nocontent when deleted</response>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteUser(id, cancellationToken);
        return NoContent();
    }
}
