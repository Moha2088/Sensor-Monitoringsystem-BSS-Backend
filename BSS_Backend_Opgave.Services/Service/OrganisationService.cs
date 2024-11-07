using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationService(IOrganisationRepository organisationRepository) => _organisationRepository = organisationRepository;



        public async Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto, CancellationToken cancellationToken)
        {
            var user = await _organisationRepository.CreateOrganisation(dto, cancellationToken);
            return user;
        }

        public async Task DeleteOrganisation(int id, CancellationToken cancellationToken)
        {
            await _organisationRepository.DeleteOrganisation(id, cancellationToken);
        }

        public async Task<OrganisationGetDto> GetOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _organisationRepository.GetOrganisation(id, cancellationToken);
            return organisation;
        }

        public async Task<IEnumerable<OrganisationGetDto>> GetOrganisations(CancellationToken cancellationToken)
        {
            var organisations = await _organisationRepository.GetOrganisations(cancellationToken);
            return organisations;
        }


    }
}
