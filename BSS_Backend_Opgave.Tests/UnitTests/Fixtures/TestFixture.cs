using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.StateDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.UnitTests.Fixtures
{
    public class TestFixture : IDisposable
    {
        public BSS_Backend_OpgaveAPIContext Context { get; private set; }

        public IMapper Mapper { get; private set; }


        public TestFixture()
        {
            var options = new DbContextOptionsBuilder<BSS_Backend_OpgaveAPIContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            Context = new BSS_Backend_OpgaveAPIContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserCreateDTO, User>();
                cfg.CreateMap<User, UserGetDto>();
                cfg.CreateMap<SensorCreateDto, Sensor>();
                cfg.CreateMap<Sensor, SensorGetDto>();
                cfg.CreateMap<EventLogCreateDto, EventLog>();
                cfg.CreateMap<EventLog, EventLogGetDto>()
                .ForMember(dest => dest.StateType, opt => opt.MapFrom(src => src.State.StateType));
                cfg.CreateMap<StateCreateDto, State>();
            });

            Mapper = config.CreateMapper();
        }

        public void Dispose() => Context.Dispose();
    }
}
