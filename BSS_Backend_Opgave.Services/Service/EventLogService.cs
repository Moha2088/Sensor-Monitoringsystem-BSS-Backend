using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.Services.Service
{
    public class EventLogService : IEventLogService
    {
        private readonly IEventLogRepository _eventLogRepository;

        public EventLogService(IEventLogRepository eventLogRepository)
        {
            _eventLogRepository = eventLogRepository;
        }

        public async Task<IEnumerable<EventLogGetDto>> GetEventLogs(int organisationId, CancellationToken cancellationToken)
        {
            var eventLogs = await _eventLogRepository.GetEventLogs(organisationId, cancellationToken);
            return eventLogs;
        }

        public async Task<EventLogGetDto> UpdateState(int sensorId)
        {
            var eventLog = await _eventLogRepository.UpdateState(sensorId);
            return eventLog;
        }
    }
}
