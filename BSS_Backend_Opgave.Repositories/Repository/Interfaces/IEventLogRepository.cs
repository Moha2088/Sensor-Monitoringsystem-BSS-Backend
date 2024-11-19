using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.Repositories.Repository.Interfaces
{
    public interface IEventLogRepository
    {
        Task<EventLogGetDto> UpdateState();

        Task<IEnumerable<EventLogGetDto>> GetEventLogs(int organisationId, CancellationToken cancellationToken);
    }
}
