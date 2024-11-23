using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Tests.IntegrationTests.Factory;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.IntegrationTests
{
    public class AuthenticationControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public AuthenticationControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task AuthenticateUser_ShouldReturn200OK_WhenUserCredentialsAreValid()
        {
            var authDto = new AuthenticateUserDto
            {
                Email = "mo@ucl.com",
                Password = "Mohac123"
            };

            var result = await _client.PostAsJsonAsync("api/Authentication/login", authDto);

            result.Should().NotBeNull();
            result.IsSuccessStatusCode.Should().BeTrue();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
