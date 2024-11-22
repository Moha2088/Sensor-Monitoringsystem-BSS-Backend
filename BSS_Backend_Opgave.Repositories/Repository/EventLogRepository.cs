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
using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Repositories.Models.Dtos.StateDtos;

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


        public async Task<IEnumerable<EventLogGetDto>> GetEventLogs(int organisationId, CancellationToken cancellationToken)
        {
            var eventLog = await _context.EventLog
                .AsNoTracking()
                .Include(eventLog => eventLog.Sensor)
                .Include(eventLog => eventLog.State)
                .Where(eventLog => eventLog.Sensor.OrganisationId.Equals(organisationId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<EventLogGetDto>>(eventLog);
        }

        public async Task<EventLogGetDto> UpdateState(int sensorId)
        {
            var sensor = await _context.Sensor
                .Include(sensor => sensor.EventLogs)
                .Include(sensor => sensor.State)
                .SingleOrDefaultAsync(sensor => sensor.Id.Equals(sensorId));

            var eventLog = new EventLog
            {
                EventTime = DateTimeOffset.UtcNow,
                SensorId = sensor.Id
            };

            sensor.EventLogs.Add(eventLog);

            if (sensor.State != null)
            {
                _context.State.Remove(sensor.State);
            }

            var state = new State
            {
                StateType = "DRONE SPOTTED",
                SensorId = sensor.Id,
                EventLog = eventLog
            };

            sensor.State = state;
            
            await _context.SaveChangesAsync();
            return _mapper.Map<EventLogGetDto>(eventLog);
        }
    }
}
