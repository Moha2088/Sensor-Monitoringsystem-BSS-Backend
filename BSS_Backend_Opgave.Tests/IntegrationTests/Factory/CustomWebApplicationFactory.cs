using BSS_Backend_Opgave.API;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.Repositories.Models.Dtos;
using BSS_Backend_Opgave.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Tests.IntegrationTests.Factory
{
    public class CustomWebApplicationFactory : WebApplicationFactory<IApiMarker>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(service =>
            {
                var existingDbContext = service
               .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<BSS_Backend_OpgaveAPIContext>));

                if (existingDbContext != null)
                {
                    service.Remove(existingDbContext);
                }

                service.AddDbContext<BSS_Backend_OpgaveAPIContext>(opt =>
                {
                    opt.UseInMemoryDatabase("TestDBIntegration");
                });


                // This section adds authentication so authorized endpoints can be tested
                var existingAuthScheme = service.SingleOrDefault(x => x.ServiceType == typeof(IAuthenticationSchemeProvider));

                if (existingAuthScheme != null)
                {
                    service.Remove(existingAuthScheme);
                }

                service.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = "TestAuthenticationScheme";
                    opt.DefaultChallengeScheme = "TestAuthenticationScheme";
                }).AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("TestAuthenticationScheme", options => { });
            });
        }

        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);


           
        }
    }
}
