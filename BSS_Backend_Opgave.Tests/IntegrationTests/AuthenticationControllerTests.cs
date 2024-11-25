using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Tests.IntegrationTests.Factory;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
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
            using var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BSS_Backend_OpgaveAPIContext>();
            context.Database.EnsureCreated();

            context.User.Add(new Models.User
            {
                Name = "test",
                Email = "test@testtest.com",
                Password = "Test"
            });

            await context.SaveChangesAsync();

            var authDto = new AuthenticateUserDto
            {
                Email = "test@testtest.com",
                Password = "Test"
            };

            var result = await _client.PostAsJsonAsync("api/Authentication/login", authDto);

            result.Should().NotBeNull();
            result.IsSuccessStatusCode.Should().BeTrue();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
