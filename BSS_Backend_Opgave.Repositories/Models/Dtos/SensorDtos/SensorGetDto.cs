using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos
{
    public class SensorGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
