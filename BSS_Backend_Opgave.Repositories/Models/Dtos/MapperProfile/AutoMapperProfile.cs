using AutoMapper;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.OrganisationDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.SensorDtos;
using BSS_Backend_Opgave.Repositories.Models.Dtos.StateDtos;


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

            #region EventLogs

            CreateMap<EventLogCreateDto, EventLog>();
            CreateMap<EventLog, EventLogGetDto>()
                .ForMember(dest => dest.StateType, opt => opt.MapFrom(src => src.State!.StateType))
                .ForMember(dest => dest.OrganisationId, opt => opt.MapFrom(src => src.Sensor.OrganisationId));

            #endregion

            #region Sensor

            CreateMap<SensorCreateDto, Sensor>();
            CreateMap<Sensor, SensorGetDto>();

            #endregion

            #region State

            CreateMap<StateCreateDto, State>();
            CreateMap<State, StateGetDto>();

            #endregion
        }
    }
}
