using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Services.Service.Interfaces
{
    public interface IOrganisationService
    {
        Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto, CancellationToken cancellationToken);
        Task<IEnumerable<OrganisationGetDto>> GetOrganisations(CancellationToken cancellationToken);
        Task<OrganisationGetDto> GetOrganisation(int id, CancellationToken cancellationToken);
        Task DeleteOrganisation(int id, CancellationToken cancellationToken);
    }
}
