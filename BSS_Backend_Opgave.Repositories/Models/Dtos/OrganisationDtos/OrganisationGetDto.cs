using BSS_Backend_Opgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos
{
    public class OrganisationGetDto
    {
        public int Id { get; set; }
            
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public List<Sensor> Sensors { get; set; }
    }
}
