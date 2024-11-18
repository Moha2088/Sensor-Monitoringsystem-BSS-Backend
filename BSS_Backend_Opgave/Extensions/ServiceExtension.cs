using BSS_Backend_Opgave.Repositories.Models.Dtos.MapperProfile;
using BSS_Backend_Opgave.Repositories.Repository;
using BSS_Backend_Opgave.Repositories.Repository.Interfaces;
using BSS_Backend_Opgave.Services.Service;
using Scrutor;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.API.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection collection)
        {
            var repositoryAssembly = typeof(IUserRepository).Assembly;
            var serviceAssembly = typeof(IUserService).Assembly;

            collection.Scan(scan =>
                scan.FromAssemblies(repositoryAssembly ,serviceAssembly)
                    .AddClasses(classes => classes.Where(c =>
                        c.Name.EndsWith("Repository") ||
                        c.Name.EndsWith("Service")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            collection.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}