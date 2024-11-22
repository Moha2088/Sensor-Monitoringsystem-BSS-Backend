using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.StateDtos;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Tests.UnitTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.UnitTests
{
    public class EventLogRepositoryTests : IClassFixture<TestFixture>
    {
        private readonly EventLogRepository _eventLogRepository;
        private readonly TestFixture _fixture;

        public EventLogRepositoryTests(TestFixture fixture) 
        {
            _fixture = fixture;
            _eventLogRepository = new EventLogRepository(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public async Task UpdateState_ShouldReturnEventLogWithUpdatedState()
        {
            var dto = new SensorCreateDto
            {
                Name = "TestSensor",
                Location = "TestLocation"
            };

            var sensor = _fixture.Mapper.Map<Sensor>(dto);
            _fixture.Context.Sensor.Add(sensor);

            var eventLogDto = new EventLogCreateDto
            {
                EventTime = DateTimeOffset.Now
            };

            var eventLog = _fixture.Mapper.Map<Models.EventLog>(eventLogDto);
            eventLog.SensorId = sensor.Id;

            var expectedStateType = "DRONE SPOTTED";
            var stateDto = new StateCreateDto
            {
                StateType = expectedStateType
            };

            var state = _fixture.Mapper.Map<State>(stateDto);
            sensor.State = state;
            await _fixture.Context.SaveChangesAsync();
            var result = await _eventLogRepository.UpdateState(sensor.Id);

            
            Assert.NotNull(result);
            Assert.IsType<EventLogGetDto>(result);
            Assert.Equal(expectedStateType, result.StateType);
        }
    }
}
