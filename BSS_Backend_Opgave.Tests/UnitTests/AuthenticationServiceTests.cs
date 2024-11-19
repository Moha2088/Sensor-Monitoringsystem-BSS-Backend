using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Services.Service;
using BSS_Backend_Opgave.Tests.UnitTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.UnitTests
{
    public class AuthenticationServiceTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;
        private readonly AuthenticationService _service;

        public AuthenticationServiceTests(TestFixture fixture)
        {
            _fixture = fixture;
            _service = new AuthenticationService(_fixture!.Context);
        }


        [Fact]
        public async Task AuthenticateUser_ShouldReturnAuthenticateUserGetDto_WhenUserExists()
        {
            var user = new User
            {
                Name = "JohnDoe",
                Email = "JohnDoe@doe.com",
                Password = "JohnDoe123"
            };


            _fixture.Context.User.Add(user);
            await _fixture.Context.SaveChangesAsync();

            var authUserDto = new AuthenticateUserDto
            {
                Email = user.Email,
                Password = user.Password
            };


            var result = await _service.AuthenticateUser(authUserDto);

            Assert.NotNull(result);
            Assert.IsType<AuthenticateUserGetDto>(result);
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


            _fixture.Context.User.Add(user);
            await _fixture.Context.SaveChangesAsync();

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
