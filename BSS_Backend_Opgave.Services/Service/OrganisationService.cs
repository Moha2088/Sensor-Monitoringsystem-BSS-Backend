using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.Services.Service
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationService(IOrganisationRepository organisationRepository) => _organisationRepository = organisationRepository;


        /// <see cref="IOrganisationService.CreateOrganisation(OrganisationCreateDto, CancellationToken)"/>
        public async Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto, CancellationToken cancellationToken)
        {
            var user = await _organisationRepository.CreateOrganisation(dto, cancellationToken);
            return user;
        }

        /// <see cref="IOrganisationService.DeleteOrganisation(int, CancellationToken)
        public async Task DeleteOrganisation(int id, CancellationToken cancellationToken)
        {
            await _organisationRepository.DeleteOrganisation(id, cancellationToken);
        }

        /// <see cref="IOrganisationService.GetOrganisation(int, CancellationToken)"/>
        public async Task<OrganisationGetDto> GetOrganisation(int id, CancellationToken cancellationToken)
        {
            var organisation = await _organisationRepository.GetOrganisation(id, cancellationToken);
            return organisation;
        }

        /// <see cref="IOrganisationService.GetOrganisations(CancellationToken)"/>
        public async Task<IEnumerable<OrganisationGetDto>> GetOrganisations(CancellationToken cancellationToken)
        {
            var organisations = await _organisationRepository.GetOrganisations(cancellationToken);
            return organisations;
        }


    }
}
