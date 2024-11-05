using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;

namespace BSS_Backend_Opgave.API.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection collection)
        {

            #region User
            collection.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Sensor
            collection.AddScoped<ISensorRepository, SensorRepository>();
            #endregion

            #region Organisation
            collection.AddScoped<IOrganisationRepository, OrganisationRepository>();
            #endregion

        }
    }
}
