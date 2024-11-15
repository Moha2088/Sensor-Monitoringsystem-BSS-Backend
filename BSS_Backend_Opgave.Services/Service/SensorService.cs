using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        /// <see cref="ISensorService.CreateSensor(SensorCreateDto, int, CancellationToken)"/>
        public async Task<SensorGetDto> CreateSensor(SensorCreateDto dto, int organisationId, CancellationToken cancellationToken)
        {
            var sensor = await _sensorRepository.CreateSensor(dto, organisationId, cancellationToken);
            return sensor;
        }

        /// <see cref="ISensorService.DeleteSensor(int, CancellationToken)"/>
        public async Task DeleteSensor(int id, CancellationToken cancellationToken)
        {
            await _sensorRepository.DeleteSensor(id, cancellationToken);
        }

        /// <see cref="ISensorService.GetSensor(int, CancellationToken)"/>
        public async Task<SensorGetDto> GetSensor(int id, CancellationToken cancellationToken)
        {
            var sensor = await _sensorRepository.GetSensor(id, cancellationToken);
            return sensor;
        }

        /// <see cref="ISensorService.GetSensors(CancellationToken)"/>
        public async Task<IEnumerable<SensorGetDto>> GetSensors(CancellationToken cancellationToken)
        {
            var sensors = await _sensorRepository.GetSensors(cancellationToken);
            return sensors;
        }
    }
}
