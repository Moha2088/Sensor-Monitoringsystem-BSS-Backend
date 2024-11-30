using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Tests.IntegrationTests.Factory;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace BSS_Backend_Opgave.Tests.IntegrationTests
{
    public class SensorControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public SensorControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateSensor_ShouldReturn201Created_WhenCreated()
        {
            var sensor = new SensorCreateDto
            {
                Name = "TestSensor",
                Location = "TestLocation"
            };

            var result = await _client.PostAsJsonAsync("api/sensors", sensor);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}