using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos
{
    public class AuthenticateUserGetDto
    {
        public string Token { get; set; } = null!;
    }
}
