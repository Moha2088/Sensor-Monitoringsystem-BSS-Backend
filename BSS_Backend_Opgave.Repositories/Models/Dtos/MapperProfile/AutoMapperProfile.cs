using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;


namespace BSS_Backend_Opgave.Repositories.Models.Dtos.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User

            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserGetDto>();

            #endregion

            #region Organisation

            CreateMap<OrganisationCreateDto, Organisation>();
            CreateMap<Organisation, OrganisationGetDto>();

            #endregion

            #region

            CreateMap<EventLogCreateDto, EventLog>();

            #endregion

        }
    }
}
