using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BSS_Backend_Context _context;

        public UserRepository(BSS_Backend_Context context)
        {
            _context = context;
        }
        

    }
}
