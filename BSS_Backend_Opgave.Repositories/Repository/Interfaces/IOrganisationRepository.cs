using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;

namespace BSS_Backend_Opgave.Repositories.Repository.Interfaces
{
    public interface IOrganisationRepository
    {
        Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto);
        Task<IEnumerable<OrganisationGetDto>> GetOrganisations();
        Task DeleteOrganisation();
    }
}
