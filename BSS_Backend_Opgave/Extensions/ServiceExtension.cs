using BSS_Backend_Opgave.Repositories.Models.Dtos.MapperProfile;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.API.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection collection)
        {

            #region User
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IUserService, UserService>();
            #endregion

            #region Sensor
            collection.AddScoped<ISensorRepository, SensorRepository>();
            collection.AddScoped<ISensorService, SensorService>();
            #endregion

            #region Organisation
            collection.AddScoped<IOrganisationRepository, OrganisationRepository>();
            collection.AddScoped<IOrganisationService, OrganisationService>();
            #endregion

            #region AutoMapper
            collection.AddAutoMapper(typeof(AutoMapperProfile));
            #endregion

            #region Auth
            collection.AddScoped<IAuthenticationService, AuthenticationService>();
            #endregion
        }
    }
}
