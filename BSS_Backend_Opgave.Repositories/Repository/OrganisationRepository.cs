using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly BSS_Backend_OpgaveAPIContext _context;
        private readonly IMapper _mapper;

        public OrganisationRepository(BSS_Backend_OpgaveAPIContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);


        /// <see cref="IOrganisationRepository.CreateOrganisation(OrganisationCreateDto, CancellationToken)"/>
        public async Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto, CancellationToken cancellationToken)
        {
            var organisation = _mapper.Map<Organisation>(dto);
            _context.Organisation.Add(organisation);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrganisationGetDto>(organisation);
        }

        /// <see cref="IOrganisationRepository.DeleteOrganisation(int, CancellationToken)"/>
        public async Task DeleteOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisation.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            _context.Organisation.Remove(organisation!);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <see cref="IOrganisationRepository.GetOrganisation(int, CancellationToken)"/>
        public async Task<OrganisationGetDto> GetOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _context.Organisation
                .AsNoTracking()
                .Include(x => x.Users)
                .Include(x => x.Sensors)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            return _mapper.Map<OrganisationGetDto>(organisation);
        }

        /// <see cref="IOrganisationRepository.GetOrganisations(CancellationToken)"/>
        public async Task<IEnumerable<OrganisationGetDto>> GetOrganisations(CancellationToken cancellationToken)
        {
            var organisations = await _context.Organisation
                .Include(x => x.Users)
                .Include(x => x.Sensors)
                .ToListAsync(cancellationToken);


            return _mapper.Map<IEnumerable<OrganisationGetDto>>(organisations);
        }
    }
}
