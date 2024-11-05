using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Repositories;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Repositories.Data;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);



        public async Task<User> CreateUser(UserCreateDTO dto, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<User>(dto);
            _context.User.Add(mappedUser);
            await _context.SaveChangesAsync(cancellationToken);
            return mappedUser;
        }

        public async Task<UserGetDto> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _context.User.SingleOrDefaultAsync(user => user.Id.Equals(id));
            var mappedUser = _mapper.Map<UserGetDto>(user);
            return mappedUser;
        }

        public async Task<IEnumerable<UserGetDto>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _context.User.ToListAsync(cancellationToken);
            var mappedUsers = _mapper.Map<ICollection<UserGetDto>>(users);
            return mappedUsers;
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _context.User.SingleOrDefaultAsync(user => user.Id.Equals(id));
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
