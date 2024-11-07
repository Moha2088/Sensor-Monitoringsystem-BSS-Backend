using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos
{
    public class EventLogCreateDto
    {
        public DateTimeOffset EventTime { get; set; }
    }
}
