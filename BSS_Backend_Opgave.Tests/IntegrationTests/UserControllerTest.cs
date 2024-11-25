using BSS_Backend_Opgave.API;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Tests.IntegrationTests.Factory;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace BSS_Backend_Opgave.Tests.IntegrationTests
{
    public class UserControllerTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public UserControllerTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_ShouldReturn201CreatedWithUser_WhenUserHasBeenCreated()
        {
            var userDto = new UserCreateDTO
            {
                Name = "Test",
                Email = "create@test.com",
                Password = "password",
            };

            var result = await _client.PostAsJsonAsync("api/users", userDto);

            result.Should().NotBeNull();
            result.EnsureSuccessStatusCode();
            result.StatusCode.Should().Be(HttpStatusCode.Created);

        }

    }
}
