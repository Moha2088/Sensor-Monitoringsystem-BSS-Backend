using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Task<IEnumerable<SensorGetDto>> GetSensors(CancellationToken cancellationToken);

        Task DeleteSensor(int id, CancellationToken cancellationToken);
    }
}
