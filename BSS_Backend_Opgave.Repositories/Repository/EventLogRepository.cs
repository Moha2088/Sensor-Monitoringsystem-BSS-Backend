using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Models;
using AutoMapper;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public EventLogRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventLogGetDto> UpdateState()
        {
            var eventLog = new EventLog
            {
                EventTime = DateTimeOffset.Now,
                State = new State
                {
                    StateType = "DRONE SPOTTED"
                }
            };

            _context.EventLog.Add(eventLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<EventLogGetDto>(eventLog);
        }
    }
}
