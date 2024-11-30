using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface ISensorService
    {
        /// <summary>
        /// Creates a Sensor
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<SensorGetDto> CreateSensor(SensorCreateDto dto, int organisationId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a sensor
        /// </summary>
        /// <param name="id">Id of the sensor</param>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <returns></returns>
        Task<SensorGetDto> GetSensor(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a list of sensors
        /// </summary>
        /// <param name="organisationId">Id of the organisation</param>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <returns></returns>
        Task<IEnumerable<SensorGetDto>> GetSensors(int organisationId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a sensor
        /// </summary>
        /// <param name="id">Id of the sensor</param>
        /// <param name="cancellationToken">A token for cancelling requests</param>
        /// <returns></returns>
        Task DeleteSensor(int id, CancellationToken cancellationToken);
    }
}
