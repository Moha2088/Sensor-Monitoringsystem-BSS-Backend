using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Services.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.UnitTests
{
    public class AuthenticationServiceTests
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly AuthenticationService _service;

        public AuthenticationServiceTests()
        {
            var options = new DbContextOptionsBuilder<BSS_Backend_OpgaveAPIContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            _context = new BSS_Backend_OpgaveAPIContext(options);

            _service = new AuthenticationService(_context);

        }


        [Fact]
        public async Task AuthenticateUser_ShouldReturnToken_WhenUserExists()
        {
            var user = new User
            {
                Name = "JohnDoe",
                Email = "JohnDoe@doe.com",
                Password = "JohnDoe123"
            };


            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var authUserDto = new AuthenticateUserDto
            {
                Email = user.Email,
                Password = user.Password
            };


            var result = await _service.AuthenticateUser(authUserDto);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact]
        public async Task AuthenticateUser_ShouldReturnNull_WhenUserDoesNotExist()
        {
            var user = new User
            {
                Name = "JohnDoe",
                Email = "JohnDoe1@doe.com",
                Password = "JohnDoe123"
            };


            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var authUser = new AuthenticateUserDto
            {
                Email = "JohnDoe123@doe.com",
                Password = "JohnDoe123312"
            };

            var result = await _service.AuthenticateUser(authUser);

            Assert.Null(result);
        }
    }
}
