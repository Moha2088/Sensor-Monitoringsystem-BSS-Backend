using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Tests.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.UnitTests
{
    public class OrganisationRepositoryTests : IClassFixture<TestFixture>
    {
        private readonly OrganisationRepository _organisationRepository;
        private readonly TestFixture _fixture;

        public OrganisationRepositoryTests(TestFixture fixture)
        {
            _fixture = fixture;
            _organisationRepository = new (_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public async Task CreateOrganisation_ShouldReturnCreatedOrganisation()
        {
            var cancellationToken = new CancellationToken();

            var organisationDto = new OrganisationCreateDto
            {
                Name = "TestOrganisation"
            };

            var response = await _organisationRepository.CreateOrganisation(organisationDto, cancellationToken);

            response.Should().NotBeNull();
            response.Should().BeOfType<OrganisationGetDto>();
            response.Name.Should().BeEquivalentTo(organisationDto.Name);
        }

        [Fact]
        public async Task GetOrganisation_ShouldReturnRequestedOrganisation()
        {
            var cancellationToken = new CancellationToken();

            var organisation = new Models.Organisation
            {
                Name = "TestOrg"
            };

            _fixture.Context.Organisation.Add(organisation);

            await _fixture.Context.SaveChangesAsync();

            var response = await _organisationRepository.GetOrganisation(organisation.Id, cancellationToken);

            response.Should().NotBeNull();
            response.Should().BeOfType<OrganisationGetDto>();
            response.Name.Should().BeEquivalentTo(organisation.Name);
        }

        [Fact]
        public async Task DeleteOrganisation_ShouldDeleteOrganisation()
        {
            var cancellationToken = new CancellationToken();

            var organisation = new Models.Organisation
            {
                Name = "TestOrg"
            };

            _fixture.Context.Organisation.Add(organisation);
            await _fixture.Context.SaveChangesAsync();

            await _organisationRepository.DeleteOrganisation(organisation.Id, cancellationToken);
            var deletedOrganisation = await _fixture.Context.Organisation.SingleOrDefaultAsync(org => org.Id.Equals(organisation.Id));

            deletedOrganisation.Should().BeNull();
        }
    }
}
