using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IEventLogService
    {
        /// <summary>
        /// Updates the state for a sensor
        /// </summary>
        /// <param name="id">Id of the sensor</param>
        /// <returns></returns>
        Task<EventLogGetDto> UpdateState(int sensorId);

        Task<IEnumerable<EventLogGetDto>> GetEventLogs(int organisationId, CancellationToken cancellationToken);
    }
}