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
        /// <returns></returns>
        Task<Sensor> CreateSensor(SensorCreateDto dto);
    }
}
