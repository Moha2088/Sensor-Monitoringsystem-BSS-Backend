using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IEventLogService
    {
        Task<EventLogGetDto> UpdateState();
    }
}