using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        public Task<OrganisationGetDto> CreateOrganisation(OrganisationCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrganisation()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganisationGetDto>> GetOrganisations()
        {
            throw new NotImplementedException();
        }
    }
}
