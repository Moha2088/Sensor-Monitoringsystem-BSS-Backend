using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class SensorRepository : ISensorRepository
    {
        public Task<Sensor> CreateSensor(SensorCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
