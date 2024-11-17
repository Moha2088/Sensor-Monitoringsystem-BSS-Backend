using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository.Interfaces
{
    public interface ISensorRepository
    {
        /// <summary>
        /// Creates a Sensor
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="organisationId">Id of the organisation</param>
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
        /// Gets a list of all sensors
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
